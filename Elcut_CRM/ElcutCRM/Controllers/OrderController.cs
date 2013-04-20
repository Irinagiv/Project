using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElcutCRM.Models;
using ElcutCRM.Data.Models;
using ElcutCRM.Data;

namespace ElcutCRM.Controllers
{
    public class OrderController : BaseController
    {
//      
        public ActionResult Edit(int id = 0, int organizationId = 0)
        {

            var model = new Order();

            if (id > 0)
            {
                ViewBag.Title = string.Format("Редактирование заказа");

                model = BusinessContext.OrderManager.Get(id);
            }
            else
            {
                model.OrganizationID = organizationId;
            }

            model.OrderTypes = BusinessContext.OrderManager.GetTypes();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            var pricesString = serializer.Serialize(BusinessContext.OrderManager.GetAvaliablePrices()
                .Select(x=>new { OrderTypeID = x.OrderTypeID, OptionID = x.ConfigurationOptionID, Price = x.Price}));
            if (model.VersionKey == Order.ORDER_VERSION_STUDENT)
            {
                pricesString = "[]";
            }

            ViewData["AvaliablePrices"] = pricesString;

            return View(model);
        }

        public ActionResult GetAvaliablePrices(string version)
        {
            object prices = new List<string>();

            if (version != Order.ORDER_VERSION_STUDENT)
            {
                prices = BusinessContext.OrderManager.GetAvaliablePrices()
                    .Select(x => new { OrderTypeID = x.OrderTypeID, OptionID = x.ConfigurationOptionID, Price = x.Price });
            }

            return Json(prices, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(Order model, FormCollection form)
        {
            var context = new ElcutContext();

            try
            {
                if (model.ID > 0)
                {
                    model = BusinessContext.OrderManager.Get(model.ID);
                    UpdateModel(model);
                }

                var ids = new List<short>();

                if (!string.IsNullOrEmpty(form["Options[]"]))
                {
                    var strIds = form["Options[]"]
                        .Replace("false", "")
                        .Split(",".ToCharArray());
                    foreach (var id in strIds)
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            ids.Add(short.Parse(id));
                        }
                    }
                }

                model = BusinessContext.OrderManager.Save(model);

                BusinessContext.OrderManager.UpdateOrderConfiguration(model, ids);

                return RedirectToAction("Details", "Clients", new { id = model.OrganizationID, tab="ordersTab" });
            }
            catch (Exception ex)
            {
            }

            model.OrderTypes = BusinessContext.OrderManager.GetTypes();

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Options(Order order)
        {
            var model= new ElcutCRM.Models.OrderOptionsViewModel(order);
            return PartialView("_Options", model);
        }

        public ActionResult Details(int id)
        {
            var model = BusinessContext.OrderManager.Get(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteOrder(int id)
        {
            var orgId = 0;
            try
            {
                var manager = BusinessContext.GetGenericManagerInstance<Order>();

                var model = manager.Get(id);

                orgId = model.OrganizationID;

                manager.Delete(model);
            }
            catch
            {
            }

            var org = BusinessContext.OrganizationManager.Get(orgId);

            return PartialView("~/Views/Clients/_OrderList.cshtml", BusinessContext.OrganizationManager.GetOrders(org));
        }
    }
}
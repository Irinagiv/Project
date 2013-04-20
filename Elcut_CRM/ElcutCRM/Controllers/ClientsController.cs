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
    public class ClientsController : BaseController
    {
        //
        // GET: /Clients/

        public ActionResult Index()
        {
            ViewBag.Title = "Клиенты";

            var model = new OrganizationListViewModel(BusinessContext);

            
            

            return View(model);
        }
        
        public ActionResult OrganizationList(int typeId = 0, string statusKey = null, string relationshipKey = null)
        {
            var organizations = BusinessContext.OrganizationManager.GetOrganizations(typeId, statusKey, relationshipKey);

            var model = new OrganizationListViewModel { Organizations = organizations };

            return PartialView("_OrganizationList", model);
        }

        //
        // GET: /Clients/Details/5

        public ActionResult Details(int id = 0, string tab = "organizationTab")
        {
            var model = BusinessContext.OrganizationManager.Get(id);

            ViewBag.Title = string.Format("{0} - Информация", model.Name);
            ViewBag.SelectedTab = tab;

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult OrganizationInfo(Organization model)
        {
            return PartialView("_OrganizationInfo", model);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Добавление клиента";

            var model = new Organization();

            model.CountriesList = BusinessContext.OrganizationManager.GetCountries();
            model.TypesList = BusinessContext.OrganizationManager.GetTypes();
            
            return View("Edit",model);
        }

        
        public ActionResult Edit(int id = 0)
        {
            var model = new Organization();

            if (id > 0)
            {
                ViewBag.Title = string.Format("{0} - Редактирование", model.Name);

                model = BusinessContext.OrganizationManager.Get(id);
            }

            model.TypesList = BusinessContext.OrganizationManager.GetTypes();
            model.CountriesList = BusinessContext.OrganizationManager.GetCountries();

            return View(model);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(Organization model)
        {
            if (ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    model = BusinessContext.OrganizationManager.Get(model.ID);
                    UpdateModel(model);
                }

                BusinessContext.OrganizationManager.Save(model);

                return RedirectToAction("Edit", new { id = model.ID });
            }

            model.CountriesList = BusinessContext.OrganizationManager.GetCountries();
            model.TypesList = BusinessContext.OrganizationManager.GetTypes();

            return View(model);
        }

        public ActionResult AddContact(int organizationId)
        {
            var contact = new ContactName { OrganizationID = organizationId };

            ViewBag.Title = "Добавить контакт";

            return View("EditContact", contact);
        }

        public ActionResult EditContact(int id)
        {
            var model = BusinessContext.OrganizationManager.GetContact(id);

            ViewBag.Title = "Редактировать контакт";

            return View("EditContact", model);
        }

        [HttpPost]
        public ActionResult EditContact(ContactName model)
        {
            if (ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    model = BusinessContext.OrganizationManager.GetContact(model.ID);
                    UpdateModel(model);
                }
                model = BusinessContext.OrganizationManager.AddOrUpdateContact(model);
                return RedirectToAction("Details", new { id=model.OrganizationID, tab="contactsTab"});
            }
            return View(model);
        }

        public ActionResult ContactDetails(int id)
        {
            var model = BusinessContext.OrganizationManager.GetContact(id);
            return PartialView("_ContactDetails", model);
        }

        [ChildActionOnly]
        public ActionResult Orders(Organization org)
        {
            return PartialView("_OrderList", BusinessContext.OrganizationManager.GetOrders(org));
        }

        [ChildActionOnly]
        public ActionResult History(Organization org)
        {
            return PartialView("_History", BusinessContext.OrganizationManager.GetHistory(org));
        }

        [ChildActionOnly]
        public ActionResult AddHistory(Organization org)
        {
            var model = new History { OrganizationID = org.ID };
            return PartialView("_AddHistory", model);
        }

        [HttpPost]
        public ActionResult AddHistory(History model)
        {
            BusinessContext.OrganizationManager.AddHistory(model);
            return RedirectToAction("Details", new { id = model.OrganizationID, tab = "historyTab" });
        }

        [ChildActionOnly]
        public ActionResult Documents(Organization org)
        {
            return PartialView("_Documents", BusinessContext.OrganizationManager.GetDocuments(org));
        }

        [ChildActionOnly]
        public ActionResult AddDocument(Organization org)
        {
            var model = new Document { OrganizationID = org.ID };
            return PartialView("_AddDocument", model);
        }

        [HttpPost]
        public ActionResult AddDocument(Document model)
        {
            model = BusinessContext.OrganizationManager.AddDocument(model);
            model = BusinessContext.OrganizationManager.GetDocument(model.ID);
            SendEmail(model);
            return RedirectToAction("Details", new { id = model.OrganizationID, tab = "documentsTab" });
        }

        [HttpPost]
        public ActionResult DeleteHistory(int id)
        {
            var orgId = 0;
            try
            {
                var manager = BusinessContext.GetGenericManagerInstance<History>();

                var model = manager.Get(id);

                orgId = model.OrganizationID;

                manager.Delete(model);
            }
            catch
            {
            }

            var org = BusinessContext.OrganizationManager.Get(orgId);

            return PartialView("_History", BusinessContext.OrganizationManager.GetHistory(org));
        }

        [HttpPost]
        public ActionResult DeleteDocument(int id)
        {
            var orgId = 0;
            try
            {
                var manager = BusinessContext.GetGenericManagerInstance<Document>();

                var model = manager.Get(id);

                orgId = model.OrganizationID;

                manager.Delete(model);
            }
            catch
            {
            }

            var org = BusinessContext.OrganizationManager.Get(orgId);

            return PartialView("_Documents", BusinessContext.OrganizationManager.GetDocuments(org));
        }

        [HttpPost]
        public ActionResult DeleteContact(int id)
        {
            var orgId = 0;
            try
            {
                var manager = BusinessContext.GetGenericManagerInstance<ContactName>();

                var model = manager.Get(id);

                orgId = model.OrganizationID;

                manager.Delete(model);
            }
            catch
            {
            }

            var org = BusinessContext.OrganizationManager.Get(orgId);

            return PartialView("_ContactList", org);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var orgId = 0;
            try
            {
                var manager = BusinessContext.GetGenericManagerInstance<Organization>();

                var model = manager.Get(id);

                manager.Delete(model);
            }
            catch
            {
            }

            return Json(new { success = true });
        }

        protected void SendEmail(Document doc) 
        {
            var controller = new MailController();
            controller.DocumentEmail(doc).Deliver();
        }
    }
}
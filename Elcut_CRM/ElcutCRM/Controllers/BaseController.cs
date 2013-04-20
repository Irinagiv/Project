using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElcutCRM.Data;

namespace ElcutCRM.Controllers
{
    public class BaseController : Controller
    {
        protected ElcutBusinessContext BusinessContext { get; set; }

        protected override void  OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.BusinessContext = new ElcutBusinessContext();

            base.OnActionExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            this.BusinessContext.Dispose();
        }
    }
}
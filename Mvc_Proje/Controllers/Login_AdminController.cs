using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje.Controllers
{
    public class Login_AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Admin"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}

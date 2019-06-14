using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje.Controllers
{
    public class Login_UserController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Kullanıcı"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reto.Backend.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [BackendAuthorize]
        public ActionResult Index()
        {
            if (Session["LoginInfo"] == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult LogOut(string fromController, string fromAction, string fromId)
        {
            this.ClearAllSession();

            string redirectUrl = "";
            if (!TempData.ContainsKey("RedirectUrl"))
            {
                redirectUrl = string.Format("/{0}/{1}", fromController, fromAction);
                if (!string.IsNullOrEmpty(fromId))
                {
                    redirectUrl = string.Concat(redirectUrl, "/", fromId);
                }

                TempData["RedirectUrl"] = redirectUrl;
            }

            return RedirectToAction("Login", "Account");
        }

        private void ClearAllSession()
        {
            Session.RemoveAll(); //清空Session
        }
    }
}
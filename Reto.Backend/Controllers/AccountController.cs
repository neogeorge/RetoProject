using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Reto.Class;
using Reto.Helper;
using Reto.Models;
using Reto.Backend.Models;

namespace Reto.Backend.Controllers
{
    public class AccountController : BaseController
    {
        #region 建構式
        private IBackendUserRepository _userRepository;
        private IBackendMenuRepository _menuRepository;

        public IBackendUserRepository userRepo
        {
            get
            {
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }

        public IBackendMenuRepository menuRepo
        {
            get
            {
                return _menuRepository;
            }
            set
            {
                _menuRepository = value;
            }
        }

        public AccountController(
            IBackendUserRepository userReposiotry,
            IBackendMenuRepository menuRepository)
        {
            _userRepository = userReposiotry;
            _menuRepository = menuRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            model.ErrorMsg = string.Empty;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                bool isEmail = RegexHelper.IsValidEmail(model.Email);
                model.Password = EncryptHelper.SHA256(model.Password);

                var user = userRepo.GetUser(model.Email, model.Password, isEmail);

                if (user == null)
                {
                    LogHelper.Error(this.logInfo, new Exception(string.Format("查無此:{0} 帳號", model.Email)));
                    model.ErrorMsg = "查無此帳號,請聯絡管理員!";
                    return View(model);
                }

                Session["LoginUserId"] = user.UserId;
                Session["BackendMenuList"] = menuRepo.GetMenuPageListByUser(model.Email, isEmail);

                LogHelper.Success(this.logInfo, "Login", "Post-Login", "登入");
                LoginLogHelper.Record(LoginStatus.Lgoin, this.loginLogInfo);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                LogHelper.Error(this.logInfo, ex);
                throw ex;
            }
        }
    }
}
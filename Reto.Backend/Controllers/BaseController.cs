using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using Reto.Class;
using Reto.Helper;

namespace Reto.Backend.Controllers
{
    public class BaseController : Controller
    {
        #region Variables
        protected string currentAction = null;
        protected string currentController = null;
        protected string currentId = null;
        protected string loginUserId = null;
        public BackendLog _log = new BackendLog();
        public BackendLoginLog _loginLog = new BackendLoginLog();

        public BackendLog logInfo
        {
            get
            {
                return _log;
            }
            set
            {
                _log = value;
            }
        }

        public BackendLoginLog loginLogInfo
        {
            get
            {
                return _loginLog;
            }
            set
            {
                _loginLog = value;
            }
        }

        #endregion

        #region Initialize
        /// <summary>
        /// 透過Initialize建立路徑及登入資訊
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            # region 解析出網址所帶的Controller、Action、Id資訊
            //自網址解析出網址資料
            currentController = this.RouteData.Values["Controller"].ToString();
            currentAction = this.RouteData.Values["Action"].ToString();
            currentId = this.RouteData.Values["Id"] == null ? "" : this.RouteData.Values["Id"].ToString();
            loginUserId = Session["LoginUserId"] != null ? Session["LoginUserId"].ToString() : "System";

            //寫入ViewData
            //ViewData["Controller"] = currentController;
            //ViewData["Action"] = currentAction;
            //ViewData["Value"] = currentId;

            //寫入Session
            logInfo.ActionLink = Request.Url.AbsolutePath;
            logInfo.Controller = currentController;
            logInfo.Action = currentAction;
            logInfo.ClientIP = loginLogInfo.ClientIP = IPHelper.LocalIPAddress();
            logInfo.CreateUser = loginLogInfo.CreateUser = loginUserId;
            Session["LoginInfo"] = logInfo;
            //Session["Controller"] = currentController;
            //Session["Action"] = currentAction;
            //Session["CurrnetPath"] = Request.Url.AbsolutePath;
            //Session["UserIP"] = IPHelper.LocalIPAddress();
            # endregion


        }
        #endregion

        /// <summary>
        /// 程式執行的base區塊
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Execute(System.Web.Routing.RequestContext requestContext)
        {
            try
            {
                base.Execute(requestContext);
            }
            catch (Exception)
            {
#if DEBUG
                throw; //若為開發模式，則將return錯誤
#endif
            }
        }

        #region MvcPaging
        private int _PageSize = 10;
        protected int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        protected IPagedList<T> PagedList<T>(IQueryable<T> source, int? page, int? total) where T : class
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return source.ToPagedList<T>(currentPageIndex, _PageSize, total);
        }
        protected IPagedList<T> PagedList<T>(IEnumerable<T> source, int? page, int? total) where T : class
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return source.ToPagedList<T>(currentPageIndex, _PageSize, total);
        }
        protected IPagedList<T> PagedList<T>(List<T> source, int? page, int? total) where T : class
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return source.ToPagedList<T>(currentPageIndex, _PageSize, total);
        }
        #endregion
    }
}
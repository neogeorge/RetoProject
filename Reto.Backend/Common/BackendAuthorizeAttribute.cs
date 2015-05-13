using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Reto.Backend
{
    public class BackendAuthorizeAttribute : AuthorizeAttribute
    {
        #region Private Variables
        //將要瀏覽的頁面網址資訊
        private string gotoControllerName, gotoActionName, gotoId;
        private bool successAuthorize = false;//是否有權限
        //private bool sessionlost = false; //登入者的Session是否有效
        private bool gotoMainPage = false; //是否前往首頁(若有登入但欲進入無權限的頁面，則導向首頁)
        //private string routeController; //預設的導往Controller
        private string routeAction; //預設的導往Action
        #endregion

        /// <summary>
        /// 判斷使用者是否已獲得授權
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            gotoMainPage = false;

            if (httpContext.Session["LoginUserId"] == null ||
                string.IsNullOrEmpty((httpContext.Session["LoginUserId"].ToString())))
            {
                successAuthorize = false;
                //sessionlost = true;
                return successAuthorize;
            }

            //檢查將要瀏覽的頁面該使用者是否有權限,頁面權限尚未規劃完整.暫時先開通
            successAuthorize = true;

            return successAuthorize;
        }

        /// <summary>
        /// 求授權時所呼叫的判斷
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            gotoControllerName = filterContext.RouteData.Values["Controller"].ToString();
            gotoActionName = filterContext.RouteData.Values["Action"].ToString();
            gotoId = (filterContext.RouteData.Values["Id"] == null ? "" : filterContext.RouteData.Values["Id"].ToString());

            base.OnAuthorization(filterContext);

            if (gotoMainPage)
                routeAction = "Index";
            else
                routeAction = "LogOut";

            //若無權限則導入下列Rounting
            if (!successAuthorize)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                                    new
                                    {
                                        controller = "Home",
                                        action = routeAction,
                                        fromController = gotoControllerName,
                                        fromAction = gotoActionName,
                                        fromId = gotoId
                                    }));
            }
        }
    }
}
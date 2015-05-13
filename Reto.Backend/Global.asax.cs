using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using Reto.Models;

namespace Reto.Backend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Autofac.IContainer container = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            AutoMapperConfig.Init();
            this.SetupAutofac();
        }

        private void SetupAutofac()
        {
            //建立Builder
            var builder = new ContainerBuilder();

            //選擇載入的dll
            Assembly[] assColl = new Assembly[] 
            { 
                Assembly.Load("Reto.Models"), 
                Assembly.Load("Reto.Backend") 
            };

            //註冊assembly
            builder.RegisterAssemblyTypes(assColl).AsImplementedInterfaces().SingleInstance();

            //取得Controlller位置
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Build
            container = builder.Build();

            //Web Mvc 整合
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //Web Api整合
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

﻿using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using api.docs.admin.Dependencies;
using log4net;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace api.docs.admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }


        protected override void OnApplicationStarted()
        {
            _logger.Info("Logging configured");

            RegisterRoutes(RouteTable.Routes);

            _logger.Info("Routes registered");
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new INinjectModule[] {new DataModule()});
        }
    }
}
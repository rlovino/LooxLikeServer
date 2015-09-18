using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using LooxLikeAPI.Windsor;

namespace LooxLikeAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        private readonly WindsorContainer _container;

        public WebApiApplication()
        {
            this._container = new WindsorContainer();
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(_container.Kernel);
            _container.Install(FromAssembly.This());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        

    }
}

using LooxLikeAPI.App_Start;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Repository;
using LooxLikeAPI.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LooxLikeAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //dependency injection
            var container = new UnityContainer();
            container.RegisterType<IPostService, PostService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostRepository, PostRepositoryStub>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostMapper, PostMapper>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);



        }

    }
}

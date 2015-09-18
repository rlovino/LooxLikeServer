using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;

namespace LooxLikeAPI.Windsor
{
    public class WindsorDependencyScope : IDependencyScope
    {

        private readonly IKernel _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IKernel container)
        {
            this._container = container;
            this._scope = container.BeginScope();
        }


        public void Dispose()
        {
            this._scope.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return this._container.HasComponent(serviceType) ? this._container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.ResolveAll(serviceType).Cast<object>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace SOA.WebTest.Utility
{
    public class UnityDependencyResolver : IDependencyResolver
    {

        private IUnityContainer _unityContainer = null;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _unityContainer = container;
        }

        public IDependencyScope BeginScope()
        {
            return new UnityDependencyResolver(_unityContainer.CreateChildContainer());
        }

        public void Dispose()
        {
            this._unityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
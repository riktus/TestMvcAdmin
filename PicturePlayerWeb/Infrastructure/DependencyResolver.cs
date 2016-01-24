using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using PicturePlayerWeb.DataContext.Factory.Interfaces;
using PicturePlayerWeb.DataContext.Factory.Implementations;
using PicturePlayerWeb.Entity;
using PicturePlayerWeb.Models.Interfaces;
using PicturePlayerWeb.Models.Implementations.Repository;
using PicturePlayerWeb.Infrastructure.Interfaces;
using PicturePlayerWeb.Infrastructure.Implementations;

namespace PicturePlayerWeb.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;
        public DependencyResolver(IKernel kernelCtor)
        {
            kernel = kernelCtor;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IDatabaseModelContextFactory>().To<MsSqlModelContextFactory>();
            kernel.Bind<IRepository<PictureElement>>().To<PictureElementsRepository>();

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}
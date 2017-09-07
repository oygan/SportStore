using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Concrete.Repository;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;

namespace SportsStore.WebUI
{
    /// <summary>
    /// This class implements DI container logic.
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _nKernel;

        public NinjectDependencyResolver(IKernel nKernel)
        {
            _nKernel = nKernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _nKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _nKernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _nKernel.Bind<IProductsRepository>().To<EFProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            _nKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            _nKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}
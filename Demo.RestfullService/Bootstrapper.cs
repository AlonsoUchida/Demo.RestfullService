using System.Web.Http;
//using DataModel.UnitOfWork;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using UnityResolver;
using System;
using Demo.RestfullService.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Demo.RestfullService.Controllers;

namespace Bonus.WebApi
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Component initialization via MEF
            //http://stackoverflow.com/questions/31832618/how-to-inject-dbcontext-implementation-into-prism-viewmodel-constructor
            //http://stackoverflow.com/questions/24731426/register-iauthenticationmanager-with-unity
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            ComponentLoader.LoadContainer(container, ".\\bin", "Demo.WebApi.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "Demo.BusinessServices.dll");
        }
    }
}
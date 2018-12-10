using Data;
using Interfaces;
using Repositories;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace USP_Application
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            RegisterTypes(container);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterType<ProductDBContext, ProductDBContext>();
            //container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<DB_Context, DB_Context>();
            container.RegisterType<IClient, ClientRepository>();
            container.RegisterType<IUserLogin, UserLoginRepository>();
            container.RegisterType<ICity, CityRepository>();
            container.RegisterType<IArea, AreaRepository>();

        }
    }
}
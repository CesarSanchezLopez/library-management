using System.Web.Http;
using Unity;
using Unity.WebApi;
using LibraryManagement.API.Interfaces;
using LibraryManagement.API.Services;

namespace LibraryManagement.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILibroService, LibroService>();
            container.RegisterType<IAutorService, AutorService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
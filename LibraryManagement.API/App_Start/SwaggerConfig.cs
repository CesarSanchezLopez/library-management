using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(LibraryManagement.API.SwaggerConfig), "Register")]

namespace LibraryManagement.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var config = GlobalConfiguration.Configuration;

            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Library Management API")
                     .Description("API para gestión de Libros y Autores");

                    // Si activas XML documentation luego, descomenta esto:
                    // c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Library API - Swagger");
                });
        }

        // SOLO si activas documentación XML
        // private static string GetXmlCommentsPath()
        // {
        //     return System.String.Format(@"{0}\bin\LibraryManagement.API.xml",
        //         System.AppDomain.CurrentDomain.BaseDirectory);
        // }
    }
}
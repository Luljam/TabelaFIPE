using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace TabelaFIPE.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection service)
        {
            return service.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Tabela Fipe .Net Core",
                    Version = "v1",
                    Description = "Desenvolvimento de Api com .Net Core.",
                    Contact = new OpenApiContact
                    {
                        Name = "Luciano Brito",
                        Email = "lucianofdebrito@gmail.com"
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlPath = Path.Combine("wwwroot", "api-doc.xml");
                opt.IncludeXmlComments(xmlPath);
            });
        }

        // Configurações da rota. Será lido me classe StartUp Configure
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                //c.RoutePrefix = "documentation";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}

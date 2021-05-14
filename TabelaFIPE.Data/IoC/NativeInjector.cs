using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TabelaFIPE.Application.Interfaces;
using TabelaFIPE.Application.Services;

namespace TabelaFIPE.Data.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IMarcasServices, MarcasServices>();
            services.AddScoped<IVeiculosServices, VeiculosServices>();

            #endregion

            #region Repositories

            #endregion
        }
    }
}

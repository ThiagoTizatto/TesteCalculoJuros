using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Servico.Recursos.Juros;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraJuros.Api.Juros.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {

            services.AddScoped<IJuroService, JuroService>();

            return services;
        }
    }
}

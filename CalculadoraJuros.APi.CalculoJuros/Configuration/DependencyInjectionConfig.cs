using CalculadoraJuros.APi.CalculoJuros.Util;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Servico.Recursos.Juros;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraJuros.APi.CalculoJuros.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {

            services.AddScoped<IJuroService, JuroService>();

            services.AddScoped<Requisicao>();

            return services;
        }
    }
}

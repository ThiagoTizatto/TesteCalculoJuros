using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraJuros.APi.CalculoJuros.Configuration
{

    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Teste Calculo Juros",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago Stefen",
                        Email = "Thiago.stefen@gmail.com",
                    }
                });

            });

            return services;
        }
    }
}

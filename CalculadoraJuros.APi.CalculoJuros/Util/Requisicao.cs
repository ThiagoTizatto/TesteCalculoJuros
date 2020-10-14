using CalculadoraJuros.APi.CalculoJuros.Configuration;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculadoraJuros.APi.CalculoJuros.Util
{
    public class Requisicao
    {
        private readonly AppSettings _appSettings;
        public Requisicao(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public async Task<double> ObterTaxa()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_appSettings.UrlAPI);
            if (response.IsSuccessStatusCode)
            {
            
                var taxa = JsonConvert.DeserializeObject<Taxa>((response.Content.ReadAsStringAsync().Result));
                return taxa.Valor;
            }
            else
            {
                return 0;
            }
      
        }
    }
}

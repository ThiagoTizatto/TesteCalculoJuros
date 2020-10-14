using CalculadoraJuros.APi.CalculoJuros;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CalculadoraJuros.Teste.Integracao.ConfigPadrao
{
    public class TesteBaseCalculoJuros
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        public TesteBaseCalculoJuros()
        {
            Setup();
        }
        private void Setup()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }

    }
}


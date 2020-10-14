using CalculadoraJuros.Dominio.Entidades.Taxas;
using CalculadoraJuros.Teste.Comum.Inicializador;
using CalculadoraJuros.Teste.Integracao.ConfigPadrao;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace CalculadoraJuros.Teste.Integracao.CalculoJuros
{
    class TesteIntegracaoCalculoJuros : TesteBase
    {
        private TesteBaseCalculoJuros _testeBaseCalculoJuros;



        //[Test]
        //public async Task Validar_Juro_Deve_ser_Ok()
        //{
        //    var resultado = await _testeBaseCalculoJuros.Client.GetAsync("/juros/taxaJuros");
        //    var conteudo = await resultado.Content.ReadAsStringAsync();
        //    var valor = JsonConvert.DeserializeObject<double>(conteudo);

        //    double valorFinal  =

        //    resultado.StatusCode.Should().Be(HttpStatusCode.OK);

        //    Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        //    Assert.Equal(0.01, taxa.TaxaJuros);

        //}

        public override void Initialize()
        {
            _testeBaseCalculoJuros = new TesteBaseCalculoJuros();
        }
    }
}

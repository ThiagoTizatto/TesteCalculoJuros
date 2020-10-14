using CalculadoraJuros.Api.Juros.Controllers;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using CalculadoraJuros.Teste.Comum.Inicializador;
using CalculadoraJuros.Teste.Comum.ObjetoPadrao;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalculadoraJuros.Teste.Api.Recursos.Juros
{
    public class TesteAPIJuros : TesteBase
    {
        private Mock<IJuroService> _service;
        public override void Initialize()
        {
            _service = new Mock<IJuroService>();
        }

        private JurosController ObterJurosController()
        {
            return new JurosController(_service.Object);
        }



       [Test]
        public void JurosController_ObterTaxa_Deve_ser_OK()
        {
            // Arrange
                
            _service.Setup(s => s.ObterTaxa(It.IsAny<Taxa>())).Returns(TaxaObjetoPadrao.Padrao);

            var controller = ObterJurosController();

            // Action
            var retorno = controller.ObterTaxa();

            //Assert
            var resultado = retorno.Should().BeOfType<ActionResult<double>>().Subject;
            //retorno.Result .Should().Be(TaxaObjetoPadrao.Padrao.Valor);
            ((Taxa)((ObjectResult)retorno.Result).Value).Valor.Should().Be(TaxaObjetoPadrao.Padrao.Valor);


            _service.Verify(s => s.ObterTaxa(It.IsAny<Taxa>()), Times.Once);
        }
    }


}

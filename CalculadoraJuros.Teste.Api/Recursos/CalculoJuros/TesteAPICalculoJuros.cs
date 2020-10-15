using CalculadoraJuros.APi.CalculoJuros.Configuration;
using CalculadoraJuros.APi.CalculoJuros.Controllers;
using CalculadoraJuros.APi.CalculoJuros.Util;
using CalculadoraJuros.Dominio.Entidades.Juros;
using CalculadoraJuros.Dominio.Entidades.Juros.Excecoes;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Teste.Comum.Inicializador;
using CalculadoraJuros.Teste.Comum.ObjetoPadrao;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculadoraJuros.Teste.Api.Recursos.CalculoJuros
{
    public class TesteAPICalculoJuros : TesteBase
    {

        private Mock<IJuroService> _service;
        private Mock<IRequisicao> _requisicao;
     

        public override void Initialize()
        {
            _service = new Mock<IJuroService>();
            _requisicao = new Mock<IRequisicao>();
            
           
        }

        private CalculoJurosController ObterCalculoJurosController()
        {
            return new CalculoJurosController(_service.Object, _requisicao.Object);
        }



        [Test]
        public void CalculoJurosController_CalculaJuros_Deve_ser_OK()
        {
            // Arrange

            _service.Setup(s => s.CalculaJuros(JuroObjetoPadrao.PadraoSemTaxa)).Returns(It.IsAny<double>());

            _requisicao.Setup(r => r.ObterTaxa()).Returns(Task.FromResult(0.01));

            var controller = ObterCalculoJurosController();

            // Action
            var retorno = controller.CalculaJuros(It.IsAny<double>(), It.IsAny<int>());

            //Assert
            var resultado = retorno.Should().BeOfType<ActionResult<Juro>>();

            _requisicao.Verify(r => r.ObterTaxa(), Times.Once);

            _service.Verify(s => s.CalculaJuros(It.IsAny<Juro>()), Times.Once);
        }


        [Test]
        public void CalculoJurosController_ShowMeTheCode_Deve_ser_OK()
        {
            // Arrange

            var controller = ObterCalculoJurosController();

            // Action
            var retorno = controller.MostrarCodigo();
            var valorRetornado = ((ObjectResult)retorno.Result).Value;


            //Assert
            valorRetornado.Should().Be("https://github.com/ThiagoTizatto/TesteCalculoJuros");
            var resultado = retorno.Should().BeOfType<ActionResult<string>>();

        }


    }


}




using CalculadoraJuros.Dominio.Entidades.Juros;
using CalculadoraJuros.Dominio.Entidades.Juros.Excecoes;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes;
using CalculadoraJuros.Servico.Recursos.Juros;
using CalculadoraJuros.Teste.Comum.Inicializador;
using CalculadoraJuros.Teste.Comum.ObjetoPadrao;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CalculadoraJuros.Teste.Servico.Recursos.Juros
{
    public class TesteServiceJuro : TesteBase
    {
        private Taxa _taxa;
        private Juro _juro;
        private IJuroService _service;

        public override void Initialize()
        {
            _taxa = null;
            _juro = null;
            _service = new JuroService();
        }

        [Test]
        public void Validar_Servico_Juro_Deve_ser_Ok()
        {
            //Cenario
            _juro = JuroObjetoPadrao.Padrao;
            double valor = 0;
            double valorFinal = 105.10;
            double valorRetornado = 0;
            //Ação
            Action act = () =>_service.CalculaJuros(_juro);
            valorRetornado = _service.CalculaJuros(_juro);
            //Validação

            valorRetornado.Should().Be(valorFinal);

            act.Should().NotThrow<MesesMaiorQueZeroException>();
            act.Should().NotThrow<ValorInicialNegativoExcecao>();
        }

        [Test]
        public void Validar_Servico_Juro_Mes_Negativo_deve_Gerar_Excecao()
        {
            //Cenario
            _juro = JuroObjetoPadrao.MesesNegativo;

            //Ação
            Action act = () => _service.CalculaJuros(_juro);

            //Validação
            act.Should().Throw<MesesMaiorQueZeroException>().WithMessage("Valor de meses tem que ser maior que zero");

        }

        [Test]
        public void Validar_Servico_Juro_ValorInicial_Negativo_deve_Gerar_Excecao()
        {
            //Cenario
            _juro = JuroObjetoPadrao.ValorInicialNegativo;


            //Ação
            Action act = () => _service.CalculaJuros(_juro);

            //Validação
            act.Should().Throw<ValorInicialNegativoExcecao>().WithMessage("Valor inicial não pode ser negativo");

        }

        [Test]
        public void Validar_Juro_TaxaNula_deve_Gerar_Excecao()
        {
            //Cenario
            _juro = JuroObjetoPadrao.TaxaNula;


            //Ação
            Action act = () => _service.CalculaJuros(_juro);

            //Validação
            act.Should().Throw<Exception>().WithMessage("Taxa não pode ser nula");

        }


        [Test]
        public void Validar_Taxa_Deve_ser_Ok()
        {
            //Cenario
            _taxa = TaxaObjetoPadrao.Padrao;
            double valor = 0;
            var taxaFinal = _service.ObterTaxa(_taxa);

            //Ação
            Action act = () => _service.ObterTaxa(_taxa);

            //Validação
            taxaFinal.Valor.Should().BeGreaterThan(valor);
            act.Should().NotThrow<TaxaNegativaExcecao>();
        }


        [Test]
        public void Validar_Taxa_Deve_Gerar_Excecao()
        {
            //Cenario
            _taxa = TaxaObjetoPadrao.ValorNegativo;

            //Ação
            Action act = () => _service.ObterTaxa(_taxa);

            //Validação
            act.Should().Throw<TaxaNegativaExcecao>().WithMessage("Valor da taxa não pode ser negativo");
        }
    }
}

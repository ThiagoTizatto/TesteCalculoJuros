using CalculadoraJuros.Dominio.Entidades.Juros;
using CalculadoraJuros.Dominio.Entidades.Juros.Excecoes;
using CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes;
using CalculadoraJuros.Teste.Comum.Inicializador;
using CalculadoraJuros.Teste.Comum.ObjetoPadrao;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Teste.Dominio.Recursos.Juros
{
    public class TesteDominioJuro : TesteBase
    {

        private Juro _juro;
        public override void Initialize()
        {
            _juro = null;
        }

        [Test]
        public void Validar_Juro_Deve_ser_Ok()
        {
            //Cenario
            _juro = JuroObjetoPadrao.Padrao;
            double valor = 0;
            double valorFinal = 105.10;

            //Ação
            Action act = () => _juro.Validar();

            //Validação
            _juro.ValorInicial.Should().BeGreaterThan(valor);
            _juro.ValorFinal().Should().Be(valorFinal);
            
            act.Should().NotThrow<MesesMaiorQueZeroException>();
            act.Should().NotThrow<ValorInicialNegativoExcecao>();
        }

        [Test]
        public void Validar_Juro_Mes_Negativo_deve_Gerar_Excecao()
        {
            //Cenario
            _juro = JuroObjetoPadrao.MesesNegativo;
 
            //Ação
            Action act = () => _juro.Validar();

            //Validação
            act.Should().Throw<MesesMaiorQueZeroException>().WithMessage("Valor de meses tem que ser maior que zero");

        }

        [Test]
        public void Validar_Juro_ValorInicial_Negativo_deve_Gerar_Excecao()
        {
            //Cenario
            _juro = JuroObjetoPadrao.ValorInicialNegativo;
  

            //Ação
            Action act = () => _juro.Validar();

            //Validação
            act.Should().Throw<ValorInicialNegativoExcecao>().WithMessage("Valor inicial não pode ser negativo");

        }

        [Test]
        public void Validar_Juro_TaxaNula_deve_Gerar_Excecao()
        {
            //Cenario
            _juro = JuroObjetoPadrao.TaxaNula;
      

            //Ação
            Action act = () => _juro.Validar();

            //Validação
            act.Should().Throw<Exception>().WithMessage("Taxa não pode ser nula");

        }
    }
}

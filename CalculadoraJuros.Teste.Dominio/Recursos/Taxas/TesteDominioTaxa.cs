using CalculadoraJuros.Teste.Comum.ObjetoPadrao;
using NUnit.Framework;
using System;
using FluentAssertions;
using CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes;
using CalculadoraJuros.Teste.Comum.Inicializador;
using CalculadoraJuros.Dominio.Entidades.Taxas;

namespace CalculadoraJuros.Teste.Dominio.Recursos
{

    public class TesteDominioTaxa : TesteBase
    {
        private Taxa _taxa;
        public override void Initialize()
        {
            _taxa = null;
        }

        [Test]
        public void Validar_Taxa_Deve_ser_Ok()
        {
            //Cenario
            _taxa = TaxaObjetoPadrao.Padrao;
            double valor = 0;
            //Ação
            Action act = () => _taxa.Validar();

            //Validação
            _taxa.Valor.Should().BeGreaterThan(valor);
            act.Should().NotThrow<TaxaNegativaExcecao>();
        }


        [Test]
        public void Validar_Taxa_Deve_Gerar_Excecao()
        {
            //Cenario
            _taxa = TaxaObjetoPadrao.ValorNegativo;
            
            //Ação
            Action act = () => _taxa.Validar();

            //Validação
            act.Should().Throw<TaxaNegativaExcecao>().WithMessage("Valor da taxa não pode ser negativo");
        }

    }
}

using CalculadoraJuros.Dominio.Entidades.Juros.Excecoes;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Juros
{
    public class Juro : Entidade
    {
        public double ValorInicial{ get; set; }

        public int Meses { get; set; }

        public Taxa Taxa { get; set; }


        private double CalcularValorFinal()
        {
            return Math.Round(ValorInicial * Math.Pow(1 + Taxa.Valor, Meses), 2);
        } 
        public double ValorFinal()
        {
            return CalcularValorFinal();
        }

        public override void Validar()
        {
            if (ValorInicial <= 0)
                throw new ValorInicialNegativoExcecao();

            if (Meses <= 0)
                throw new MesesMaiorQueZeroException();

            if (Taxa == null)
                throw new Exception("Taxa não pode ser nula");


        }
    }
}

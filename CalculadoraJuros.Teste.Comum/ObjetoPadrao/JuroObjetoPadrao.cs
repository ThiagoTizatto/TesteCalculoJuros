using CalculadoraJuros.Dominio.Entidades.Juros;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Teste.Comum.ObjetoPadrao
{
    public static class JuroObjetoPadrao
    {
        public static Juro Padrao
        {
            get
            {
                var juro = new Juro()
                {
                    ValorInicial = 100,
                    Meses = 5,
                    Taxa = TaxaObjetoPadrao.Padrao
                };

                return juro;
            }
        }

        public static Juro ValorInicialNegativo
        {
            get
            {
                var juro = new Juro()
                {
                    ValorInicial = - 100,
                    Meses = 5,
                    Taxa = TaxaObjetoPadrao.Padrao
                };

                return juro;
            }
        }

        public static Juro MesesNegativo
        {
            get
            {
                var juro = new Juro()
                {
                    ValorInicial = 100,
                    Meses =  - 5,
                    Taxa = TaxaObjetoPadrao.Padrao
                };

                return juro;
            }
        }

        public static Juro TaxaNula
        {
            get
            {
                var juro = new Juro()
                {
                    ValorInicial = 100,
                    Meses = 5,
                    Taxa = null
                };

                return juro;
            }
        }
    }
}

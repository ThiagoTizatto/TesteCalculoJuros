﻿using CalculadoraJuros.Dominio.Entidades.Taxas;

namespace CalculadoraJuros.Teste.Dominio.ObjetoPadrao
{

        public static class TaxaObjetoPadrao
        {
            public static Taxa Padrao
            {
                get
                {
                    var taxaPadrao = new Taxa()
                    {
                        Valor = 0.1
                    };

                    return taxaPadrao;
                }
            }

        public static Taxa ValorNegativo
        {
            get
            {
                var taxaPadrao = new Taxa()
                {
                    Valor =  - 0.1
                };

                return taxaPadrao;
            }
        }


    }
}

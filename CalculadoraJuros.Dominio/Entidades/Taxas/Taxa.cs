using CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Taxas
{
    public class Taxa : Entidade
    {
        public Double Valor { get; set; }

        public override void Validar()
        {
            if(Valor < 0)
                throw new TaxaNegativaExcecao();
        }
    }
}

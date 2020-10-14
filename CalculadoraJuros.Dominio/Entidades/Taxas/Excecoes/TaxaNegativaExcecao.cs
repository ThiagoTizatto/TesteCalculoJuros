using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes
{
    public class TaxaNegativaExcecao : Exception
    {
        public override string Message => "Valor da taxa não pode ser negativo";

    }
}

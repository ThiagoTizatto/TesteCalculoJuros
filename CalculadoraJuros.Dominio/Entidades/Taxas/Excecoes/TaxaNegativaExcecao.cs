using CalculadoraJuros.Dominio.ExcecaoGenerica;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes
{
    public class TaxaNegativaExcecao : BusinessException
    {
        public override string Message => "Valor da taxa não pode ser negativo";

    }
}

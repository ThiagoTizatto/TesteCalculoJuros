using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes
{
    public class ValorInicialNegativoExcecao : Exception
    {
        public override string Message => "Valor inicial não pode ser negativo";

    }
}

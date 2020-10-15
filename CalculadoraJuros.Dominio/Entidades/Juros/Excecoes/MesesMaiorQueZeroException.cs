using CalculadoraJuros.Dominio.ExcecaoGenerica;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Juros.Excecoes
{
    public class MesesMaiorQueZeroException : BusinessException
    {
        public override string Message => "Valor de meses tem que ser maior que zero";
    }
}

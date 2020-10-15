using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraJuros.APi.CalculoJuros.Util
{
    public interface IRequisicao
    {
        Task<double> ObterTaxa();
    }
}

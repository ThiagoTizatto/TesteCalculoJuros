using CalculadoraJuros.Dominio.Entidades.Taxas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Dominio.Entidades.Juros.Interfaces
{
    public interface IJuroService
    {
        public Taxa ObterTaxa(Taxa Taxa);

        public double CalculaJuros(Juro juro);


    }
}

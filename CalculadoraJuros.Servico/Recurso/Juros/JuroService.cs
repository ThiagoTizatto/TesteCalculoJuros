using CalculadoraJuros.Dominio.Entidades.Juros;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraJuros.Servico.Recursos.Juros
{
    public class JuroService : IJuroService
    {
        public double CalculaJuros(Juro juro)
        {
            juro.Validar();
            var valorFinal =  juro.ValorFinal();
            return valorFinal;
        }

        public Taxa ObterTaxa(Taxa taxa)
        {
            taxa.Validar();
            return taxa;
        }
    }
}
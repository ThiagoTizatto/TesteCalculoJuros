using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraJuros.Api.Juros.Configuration;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CalculadoraJuros.Api.Juros.Controllers
{

    [ApiController]
    [Route("api")]
    public class JurosController : ControllerBase
    {

        private IJuroService _service;
        public JurosController(IJuroService service)
        {
            _service = service;
        }

        [HttpGet("taxaJuros")]
        public ActionResult<double> ObterTaxa()
        {
           
            try
            {
                var resultado = _service.ObterTaxa(new Taxa { Valor = TaxaConfig.Valor });

                return Ok(resultado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}

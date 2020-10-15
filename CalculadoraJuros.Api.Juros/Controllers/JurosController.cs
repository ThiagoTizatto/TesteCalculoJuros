using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraJuros.Api.Juros.Configuration;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using CalculadoraJuros.Dominio.ExcecaoGenerica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CalculadoraJuros.Api.Juros.Controllers
{

    [ApiController]
    [Route("api")]
    public class JurosController : ControllerBase
    {

        private readonly IJuroService _service;
        public JurosController(IJuroService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca o valor da Taxa
        /// </summary>
        /// <returns>Retorna o valor de 0.01 que está fixo para taxa</returns>
        [HttpGet("taxaJuros")]
        public ActionResult<double> ObterTaxa()
        {
            try
            {
                var resultado = _service.ObterTaxa(new Taxa { Valor = TaxaConfig.Valor });

                return Ok(resultado);
            }
            catch (BusinessException e)
            {

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    errorMessage = e.Message,
                    stackTrace = e.InnerException.StackTrace
                });
            }

        }
    }
}

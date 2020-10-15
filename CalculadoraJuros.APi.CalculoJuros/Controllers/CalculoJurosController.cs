using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraJuros.APi.CalculoJuros.Util;
using CalculadoraJuros.Dominio.Entidades.Juros;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using CalculadoraJuros.Dominio.Entidades.Taxas.Excecoes;
using CalculadoraJuros.Dominio.ExcecaoGenerica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraJuros.APi.CalculoJuros.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalculoJurosController : ControllerBase
    {
        private readonly IJuroService _service;
        private readonly IRequisicao _requisicao;
        public CalculoJurosController(IJuroService service, IRequisicao requisicao)
        {
            _service = service;
            _requisicao = requisicao;
        }

        /// <summary>
        /// Calcula o juros
        /// </summary>
        /// <returns>Retorna o resultado do calculo: Valor Inicial * (1 + juros) ^ Tempo</returns>
        /// <param name="valorInicial"></param>  
        /// <param name="meses"></param>  
        [HttpGet("calculajuros")]
        public ActionResult<Juro> CalculaJuros([FromQuery] double valorInicial, [FromQuery] int meses)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var juro = ConstroiJuros(valorInicial, meses).Result;

                var resutado = _service.CalculaJuros(juro);

                juro.Validar();

                return Ok(resutado);
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
        /// <summary>
        /// Busca o endereço no github
        /// </summary>
        /// <returns>Retorna o endereço no github</returns>
        [HttpGet("showmethecode")]
        public ActionResult<string> MostrarCodigo()
        {
            return Ok("https://github.com/ThiagoTizatto/TesteCalculoJuros");
        }

        private async Task<Juro> ConstroiJuros(double valorInicial, int meses)
        {
            var juro = new Juro()
            {
                Meses = meses,
                ValorInicial = valorInicial
            };

            juro.Taxa = new Taxa() { Valor = await _requisicao.ObterTaxa() };
            return juro;
        }


    }
}

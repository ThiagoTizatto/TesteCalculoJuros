using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraJuros.APi.CalculoJuros.Util;
using CalculadoraJuros.Dominio.Entidades.Juros;
using CalculadoraJuros.Dominio.Entidades.Juros.Interfaces;
using CalculadoraJuros.Dominio.Entidades.Taxas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraJuros.APi.CalculoJuros.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalculoJurosController : ControllerBase
    {
        private readonly IJuroService _service;
        private readonly Requisicao _requisicao;
        public CalculoJurosController(IJuroService service, Requisicao requisicao)
        {
            _service = service;
            _requisicao = requisicao;
        }

        [HttpGet("calculajuros")]
        public ActionResult<Juro> GetJuros([FromQuery] double valorInicial, [FromQuery] int meses)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            try
            {
                var juro = ConstroiJuros(valorInicial, meses).Result;

                var resutado = _service.CalculaJuros(juro);

                return Ok(resutado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

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
                Taxa = new Taxa() { Valor = await _requisicao.ObterTaxa() },
                ValorInicial = valorInicial
            };

            return juro;
        }

     
    }
}

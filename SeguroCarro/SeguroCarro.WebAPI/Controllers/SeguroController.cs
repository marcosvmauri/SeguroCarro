using System;
using System.Collections.Generic;
using SeguroCarro.Domain.Models;
using SeguroCarro.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SeguroCarro.WebAPI.Controllers
{
    [Route("api/carroseguro")]
    [ApiController]
    public class SeguroController : Controller
    {
        private readonly ISeguroService _seguroService;

        public SeguroController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpGet("GetListSeguros", Name = "GetListSeguros")]
        public ActionResult<IEnumerable<Seguro>> Get()
        {
            try
            {
                return Ok(_seguroService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpPost("PostSeguro", Name = "PostSeguro")]
        public ActionResult<Seguro> Post([FromBody] Seguro seguro)
        {
            try
            {
                _seguroService.AddSeguroCalculado(seguro);
                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetAveragePrices", Name = "GetAveragePrices")]
        public ActionResult GetAverage()
        {
            try
            {
                return Ok(_seguroService.GetMedia());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetSeguro/{id}", Name = "GetSeguro")]
        public ActionResult<Seguro> GetById(int id)
        {
            try
            {
                return Ok(_seguroService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
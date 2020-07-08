using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SeguroCarro.Service.Interfaces;
using System.Collections.Generic;
using SeguroCarro.Domain.Models;
using System;

namespace SeguroCarro.WebAPI.Controllers
{
    [Route("api/carroseguro")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet("GetListCarros", Name = "GetListCarros")]
        public ActionResult<IEnumerable<Carro>> Get()
        {
            try
            {
                return _carroService.Get().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
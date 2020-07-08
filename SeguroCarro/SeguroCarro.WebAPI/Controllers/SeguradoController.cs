using System;
using System.Collections.Generic;
using System.Linq;
using SeguroCarro.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SeguroCarro.Service.Interfaces;

namespace SeguroCarro.WebAPI.Controllers
{
    [Route("api/carroseguro")]
    [ApiController]
    public class SeguradoController : Controller
    {
        private readonly ISeguradoService _seguradoService;

        public SeguradoController(ISeguradoService seguradoService)
        {
            _seguradoService = seguradoService;
        }

        [HttpGet("segurados", Name = "segurados")]
        public ActionResult<IEnumerable<Segurado>> Get()
        {
            try 
            { 
            return _seguradoService.Get().ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
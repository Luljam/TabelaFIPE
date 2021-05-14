using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabelaFIPE.Application.Interfaces;

namespace TabelaFIPE.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIPEController : ControllerBase
    {
        protected readonly IMarcasServices marcasServices;

        public FIPEController(IMarcasServices marcasServices)
        {
            this.marcasServices = marcasServices;
        }

        [HttpGet("marcas/{tipo}")]
        public async Task<IActionResult> GetAll(string tipo)
        {
            var marcas = await marcasServices.GetAll(tipo);
            return Ok(marcas);
        }
    }
}
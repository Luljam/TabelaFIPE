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
        protected readonly IVeiculosServices veiculosServices;

        public FIPEController(IMarcasServices marcasServices, IVeiculosServices veiculosServices)
        {
            this.marcasServices = marcasServices;
            this.veiculosServices = veiculosServices;
        }

        [HttpGet("marcas/{tipo}")]
        public async Task<IActionResult> GetAllMarcas(string tipo)
        {
            var marcas = await marcasServices.GetAll(tipo);
            return Ok(marcas);
        }

        [HttpGet("veiculo/{idMarca}")]
        public async Task<IActionResult> GetVeiculosPorMarca(int idMarca)
        {
            var veiculos = await veiculosServices.GetVeiculosMarca(idMarca);
            return Ok(veiculos);
        }

        [HttpGet("veiculo/{idMarca}/{codigoVeiculo}")]
        public async Task<IActionResult> GetVeiculo(int idMarca, string codigoVeiculo)
        {
            var veiculo = await veiculosServices.GetVeiculo(idMarca, codigoVeiculo);
            return Ok(veiculo);
        }

        [HttpGet("veiculo/{idMarca}/{codigoVeiculo}/{ano}")]
        public async Task<IActionResult> GetVeiculoAno(int idMarca, string codigoVeiculo, string ano)
        {
            var veiculoAno = await veiculosServices.GetVeiculoAno(idMarca, codigoVeiculo, ano);
            return Ok(veiculoAno);
        }
    }
}
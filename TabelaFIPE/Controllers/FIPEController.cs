using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabelaFIPE.Application.Interfaces;

namespace TabelaFIPE.Controller
{
    [Produces("application/json")]
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

        /// <summary>
        /// Pesquisa as marcas
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Retorna marcas de veiculos conforme o tipo: Carros, Motos ou Caminhoes</returns>
        /// <response code="200">Returna as marcas</response>
        /// <response code="400">Se a marca null</response>
        [HttpGet("marcas/{tipo}", Name = "GetMarcaVeiculos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMarcas(string tipo)
        {
            if(tipo == string.Empty)
            {
                return BadRequest();
            }
            var marcas = await marcasServices.GetAll(tipo);
            if(marcas == null)
            {
                return NotFound(marcas);
            }
            return Ok(marcas);
        }

        /// <summary>
        /// Retorna os veículos da marca passada no parâmento po Id da Marca
        /// </summary>
        /// <param name="idMarca"></param>
        /// <returns></returns>
        [HttpGet("veiculo/{idMarca}")]
        public async Task<IActionResult> GetVeiculosPorMarca(int idMarca)
        {
            var veiculos = await veiculosServices.GetVeiculosMarca(idMarca);
            if(veiculos == null)
            {
                return NotFound(veiculos);
            }
            return Ok(veiculos);
        }

        /// <summary>
        /// Retorna o veículo (singular), passando o Id da Marca e do código do veiculo 
        /// </summary>
        /// <param name="idMarca"></param>
        /// <param name="codigoVeiculo"></param>
        /// <returns></returns>
        [HttpGet("veiculo/{idMarca}/{codigoVeiculo}")]
        public async Task<IActionResult> GetVeiculo(int idMarca, string codigoVeiculo)
        {
            var veiculo = await veiculosServices.GetVeiculo(idMarca, codigoVeiculo);
            if(veiculo == null)
            {
                return NotFound(veiculo);
            }
            return Ok(veiculo);
        }

        /// <summary>
        /// Retorna os dados completos de valores do veículo, passando o Id da Marca, o código do veículo e o ano do veículo
        /// </summary>
        /// <param name="idMarca"></param>
        /// <param name="codigoVeiculo"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet("veiculo/{idMarca}/{codigoVeiculo}/{ano}")]
        public async Task<IActionResult> GetVeiculoAno(int idMarca, string codigoVeiculo, string ano)
        {
            var veiculoAno = await veiculosServices.GetVeiculoAno(idMarca, codigoVeiculo, ano);
            if(veiculoAno == null)
            {
                return NotFound(veiculoAno);
            }
            return Ok(veiculoAno);
        }
    }
}
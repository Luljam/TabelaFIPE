using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TabelaFIPE.Application.Exceptions;
using TabelaFIPE.Application.Interfaces;
using TabelaFIPE.Domain.Entities;

namespace TabelaFIPE.Application.Services
{
    public class VeiculosServices : IVeiculosServices
    {
        protected readonly HttpClient httpClient;

        public VeiculosServices()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://fipeapi.appspot.com/api/1/");
        }

        public async Task<IEnumerable<Veiculos>> GetVeiculosMarca(int idMarca)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"tipo/veiculos/{idMarca}.json");
                var result = await response.Content.ReadAsStringAsync();
                var veiculos = JsonConvert.DeserializeObject<IEnumerable<Veiculos>>(result);
                return veiculos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os Veiculos no provedor.", ex);
            }
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculo(int idMarca, string codigoVeiculo)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"tipo/veiculo/{idMarca}/{codigoVeiculo}.json");
                var result = await response.Content.ReadAsStringAsync();
                var veiculo = JsonConvert.DeserializeObject<IEnumerable<Veiculo>>(result);
                return veiculo;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar o Veiculo no provedor.", ex);
            }
        }

        public async Task<VeiculoAno> GetVeiculoAno(int idMarca, string codigoVeiculo, string ano)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"tipo/veiculo/{idMarca}/{codigoVeiculo}/{ano}.json");

                var result = await response.Content.ReadAsStringAsync();
                var veiculoAno = JsonConvert.DeserializeObject<VeiculoAno>(result);
                return veiculoAno;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar as informações no provedor.", ex);
            }
        }
    }
}

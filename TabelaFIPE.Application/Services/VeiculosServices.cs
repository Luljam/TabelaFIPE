using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
                var uri = new Uri($"tipo/veiculos/{idMarca}.json");
                var response = await httpClient.GetAsync(uri);
                var statusCodeRetornado = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var veiculos = JsonConvert.DeserializeObject<IEnumerable<Veiculos>>(result);
                    if (veiculos != null && veiculos.Count() > 0)
                    {
                        return veiculos;
                    }
                    throw new Exception($"Nenhum Veiculo foi encontrado.");
                }
                else
                {
                    throw new Exception("Não foi possível buscar os Veiculos.");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw new Exception("Não foi possível buscar os Veiculos no provedor.");
            }
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculo(int idMarca, int codigoVeiculo)
        {
            try
            {
                var uri = new Uri($"tipo/veiculos/{idMarca}/{codigoVeiculo}.json");
                var response = await httpClient.GetAsync(uri);
                var statusCodeRetornado = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var veiculo = JsonConvert.DeserializeObject<IEnumerable<Veiculo>>(result);
                    if (veiculo != null && veiculo.Count() > 0)
                    {
                        return veiculo;
                    }
                    throw new Exception($"Nenhum Veiculo foi encontrado.");
                }
                else
                {
                    throw new Exception("Não foi possível buscar o Veiculo.");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw new Exception("Não foi possível buscar o Veiculo no provedor.");
            }
        }

        public async Task<VeiculoAno> GetVeiculoAno(int idMarca, int codigoVeiculo, string ano)
        {
            try
            {
                var uri = new Uri($"tipo/veiculos/{idMarca}/{codigoVeiculo}/{ano}.json");
                var response = await httpClient.GetAsync(uri);
                var statusCodeRetornado = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var veiculoAno = JsonConvert.DeserializeObject<VeiculoAno>(result);
                    if (veiculoAno != null)
                    {
                        return veiculoAno;
                    }
                    throw new Exception($"Nenhuma informação foi encontrada.");
                }
                else
                {
                    throw new Exception("Não foi possível buscar informações.");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw new Exception("Não foi possível buscar as informações no provedor.");
            }
        }
    }
}

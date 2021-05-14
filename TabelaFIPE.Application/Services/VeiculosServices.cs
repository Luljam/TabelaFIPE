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
                //var uri = new Uri($"tipo/veiculos/{idMarca}.json");
                HttpResponseMessage response = await httpClient.GetAsync($"tipo/veiculos/{idMarca}.json");
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
            catch (VeiculoException ex)
            {
                throw ex;
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
                //var uri = new Uri($"tipo/veiculos/{idMarca}/{codigoVeiculo}.json");
                HttpResponseMessage response = await httpClient.GetAsync($"tipo/veiculo/{idMarca}/{codigoVeiculo}.json");
                var statusCodeRetornado = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var veiculo = JsonConvert.DeserializeObject<IEnumerable<Veiculo>>(result);
                    if (veiculo != null && veiculo.Count() > 0)
                    {
                        return veiculo;
                    }
                    throw new Exception("Nenhum Veiculo foi encontrado.");
                }
                else
                {
                    throw new Exception("Não foi possível buscar o Veiculo.");
                }
            }
            catch (VeiculoException ex)
            {
                throw ex;
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
                //var uri = new Uri($"tipo/veiculos/{idMarca}/{codigoVeiculo}/{ano}.json");
                HttpResponseMessage response = await httpClient.GetAsync($"tipo/veiculo/{idMarca}/{codigoVeiculo}/{ano}.json");
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
            catch (VeiculoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar as informações no provedor.", ex);
            }
        }
    }
}

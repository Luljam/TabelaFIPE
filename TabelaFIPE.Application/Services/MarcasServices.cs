﻿using Newtonsoft.Json;
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
    public class MarcasServices : IMarcasServices
    {
        //A API disponibiliza seus dados de busca no formato JSON.Confira a URL base de acesso a API:
        //http://fipeapi.appspot.com/api/1/[tipo]/[acao]/[parametros].json
        //O parametro [tipo] aceita três possíveis valores: carros, motos ou caminhoes.
        //O parametro [acao] está relacionado ao tipo de dados que você deseja obter.
        protected readonly HttpClient httpClient;

        public MarcasServices()
        {
            httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Marcas>> GetAll(string tipo)
        {
            try
            {
                var uri = new Uri($"http://fipeapi.appspot.com/api/1/{tipo}/marcas.json");
                var response = await httpClient.GetAsync(uri);
                var result = await response.Content.ReadAsStringAsync();
                var marcas = JsonConvert.DeserializeObject<IEnumerable<Marcas>>(result);
                return marcas;

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível buscar os Veiculos no provedor.", ex);
            }
        }
    }
}

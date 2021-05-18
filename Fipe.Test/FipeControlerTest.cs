using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TabelaFIPE.Application.Interfaces;
using TabelaFIPE.Application.Services;
using TabelaFIPE.Controller;
using TabelaFIPE.Domain.Entities;
using Xunit;

namespace Fipe.Test
{
    public class FipeControlerTest
    {

        //private readonly Mock<IMarcasServices> marcasServices = new Mock<IMarcasServices>();
        //private readonly Mock<IVeiculosServices> veiculosServices = new Mock<IVeiculosServices>();

        public FipeControlerTest()
        {

        }

        private async Task<IEnumerable<Marcas>> GetMarcas()
        {
            var marcas = new List<Marcas>();
            marcas.Add(new Marcas { Id = 1, Fipe_Name = "Audi", Key = "audi-6", Name = "AUDI", Order = 2 });
            marcas.Add(new Marcas { Id = 7, Fipe_Name = "BMW", Key = "bmw-7", Name = "BMW", Order = 2 });

            return marcas;
        }
        private async Task<IEnumerable<Marcas>> GetMarcasVazio()
        {
            var marcas = new List<Marcas>();
            return marcas;
        }

        [Fact]
        public void Get_Marcas_QuandoencontraOsDadosRetornaStatus200()
        {
            // Arrange
            var tipo = "carros";


            var mockMarcas = new Mock<IMarcasServices>();
            var mockVeiculos = new Mock<IVeiculosServices>();

            mockMarcas.Setup(m => m.GetAll(tipo)).Returns(GetMarcas());
            var controller = new FIPEController(mockMarcas.Object, mockVeiculos.Object);
            
            // Act
            var result = controller.GetAllMarcas(tipo).Result;

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, viewResult.StatusCode);
        }

        [Fact]
        public void Get_Marcas_QuandoNaoEncontraOsDadosRetorna404()
        {
            // Arrange
            var tipo = "carros";


            var mockMarcas = new Mock<IMarcasServices>();
            var mockVeiculos = new Mock<IVeiculosServices>();

            mockMarcas.Setup(m => m.GetAll(tipo)).Returns(GetMarcasVazio());

            var controller = new FIPEController(mockMarcas.Object, mockVeiculos.Object);

            // Act
            var result = controller.GetAllMarcas(tipo).Result;

            // Assert
            var viewResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, viewResult.StatusCode);
        }

        [Fact]
        public void Get_Marcas_QuandoTipoForVazioRetorna400()
        {
            // Arrange
            var tipo = string.Empty;
            var mockMarcas = new Mock<IMarcasServices>();
            var mockVeiculos = new Mock<IVeiculosServices>();

            var controller = new FIPEController(mockMarcas.Object, mockVeiculos.Object);

            // Act
            var result = controller.GetAllMarcas(tipo).Result;

            // Assert
            var viewResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, viewResult.StatusCode); // erro 400 indica que o servidor não pode ou não irá processar a requisição devido ao erro do cliente
        }

        private async Task<IEnumerable<Veiculos>> GetVeiculosMarca()
        {
            var veiculos = new List<Veiculos>();
            veiculos.Add(new Veiculos { Id = "1", Fipe_Marca = "AUDI", Key = "2", Marca = "AUDI-1", Name = "AUDI", Fipe_Name="OUTROS" });

            return veiculos;
        }

        private async Task<IEnumerable<Veiculos>> GetVeiculosMarcaVazio()
        {
            var veiculos = new List<Veiculos>();

            return veiculos;
        }

        [Fact]
        public void Veiculos_Get_QuandoencontraOsDadosRetornaStatus200()
        {
            // Arrange

            var idMarca = 26;
            var mockMarcas = new Mock<IMarcasServices>();
            var mockVeiculos = new Mock<IVeiculosServices>();
            mockVeiculos.Setup(v => v.GetVeiculosMarca(idMarca)).Returns(GetVeiculosMarca());

            var controller = new FIPEController(mockMarcas.Object, mockVeiculos.Object);

            // Act
            var result = controller.GetVeiculosPorMarca(idMarca).Result;

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, viewResult.StatusCode);
        }

        [Fact]
        public void Veiculos_Get_QuandoNaoEncontraVeiculosRetorna404()
        {
            // Arrange
            var idMarca = 26;
            var mockMarcas = new Mock<IMarcasServices>();
            var mockVeiculos = new Mock<IVeiculosServices>();
            mockVeiculos.Setup(v => v.GetVeiculosMarca(idMarca)).Returns(GetVeiculosMarcaVazio());

            var controller = new FIPEController(mockMarcas.Object, mockVeiculos.Object);

            // Act
            var result = controller.GetVeiculosPorMarca(idMarca).Result;

            // Assert
            var viewResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, viewResult.StatusCode);
        }
    }
}

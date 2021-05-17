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
            var marcas = new List<Marcas>();
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
            var marcas = new List<Marcas>();
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TabelaFIPE.Domain.Entities;

namespace TabelaFIPE.Application.Interfaces
{
    public interface IVeiculosServices
    {
        Task<IEnumerable<Veiculos>> GetVeiculosMarca(int idMarca);
        Task<IEnumerable<Veiculo>> GetVeiculo(int idMarca, string codigoVeiculo);
        Task<VeiculoAno> GetVeiculoAno(int idMarca, string codigoVeiculo, string ano);
    }
}

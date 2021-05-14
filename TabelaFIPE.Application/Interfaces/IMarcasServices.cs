using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TabelaFIPE.Domain.Entities;

namespace TabelaFIPE.Application.Interfaces
{
    public interface IMarcasServices
    {
        Task<IEnumerable<Marcas>> GetAll(string tipo);
    }
}

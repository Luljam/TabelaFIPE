using System;
using System.Collections.Generic;
using System.Text;
using TabelaFIPE.Domain.Entities;

namespace TabelaFIPE.Domain.Interfaces
{
    public interface IMarcasRepository : IRepository<Marcas>
    {
        IEnumerable<Marcas> GetAll();
    }
}

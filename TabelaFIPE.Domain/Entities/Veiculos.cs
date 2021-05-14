using System;
using System.Collections.Generic;
using System.Text;
using TabelaFIPE.Domain.Interfaces;
using TabelaFIPE.Domain.Models;

namespace TabelaFIPE.Domain.Entities
{
    public class Veiculos : Entity
    {
        public string Fipe_Name { get; set; }
        public string Fipe_Marca { get; set; }
    }
}

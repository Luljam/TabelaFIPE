using System;
using System.Collections.Generic;
using System.Text;
using TabelaFIPE.Domain.Models;

namespace TabelaFIPE.Domain.Entities
{
    public class Veiculo : Entity
    {
        public string Fipe_Marca { get; set; }
        public string Fipe_Codigo { get; set; }
        public string Nome_Veiculo { get; set; }
    }
}
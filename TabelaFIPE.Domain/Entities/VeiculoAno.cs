using System;
using System.Collections.Generic;
using System.Text;
using TabelaFIPE.Domain.Models;

namespace TabelaFIPE.Domain.Entities
{
    public class VeiculoAno: Entity
    {
        public string Fipe_Codigo { get; set; }
        public string Nome_Veiculo { get; set; }
        public string Ano_Modelo { get; set; }
        public string Preco { get; set; }
        public string Combustivel { get; set; }
        public string Referencia { get; set; }
    }
}

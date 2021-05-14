using System;
using System.Collections.Generic;
using System.Text;

namespace TabelaFIPE.Domain.Entities
{
    public class Marcas
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int Order { get; set; }
        public string Fipe_Name { get; set; }
        public string Name { get; set; }
    }
}

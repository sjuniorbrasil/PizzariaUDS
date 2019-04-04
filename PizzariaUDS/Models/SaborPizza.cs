using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaUDS.Models
{
    public class SaborPizza
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public List<SaborPizza> MetodoLista()
        {
            return new List<SaborPizza>
                {
                    new SaborPizza { ID = 0, Descricao = "CALABRESA" },
                    new SaborPizza { ID = 1, Descricao = "MARGUERITA" },
                    new SaborPizza { ID = 2, Descricao = "PORTUGUESA" }
                };
        }
    }
}

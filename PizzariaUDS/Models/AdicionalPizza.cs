using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaUDS.Models
{
    public class AdicionalPizza
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int Tempo { get; set; }
        public decimal Valor { get; set; }
        public List<AdicionalPizza> MetodoLista()
        {
            return new List<AdicionalPizza>
            {
                new AdicionalPizza { ID = 0, Descricao = "EXTRA BACON", Tempo = 0, Valor = 3 },
                new AdicionalPizza { ID = 1, Descricao = "SEM CEBOLA" , Tempo = 0, Valor = 0},
                new AdicionalPizza { ID = 2, Descricao = "BORDA RECHEADA", Tempo = 5, Valor = 5 }
            };
        }        
    }
}

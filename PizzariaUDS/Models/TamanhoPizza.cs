using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaUDS.Models
{
    public class TamanhoPizza
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int Tempo { get; set; }
        public decimal Valor { get; set; }
        public List<TamanhoPizza> MetodoLista()
        {
            return new List<TamanhoPizza>
            {
                new TamanhoPizza { ID = 0, Descricao = "PEQUENA", Tempo = 15, Valor = 20 },
                new TamanhoPizza { ID = 1, Descricao = "MÉDIA" , Tempo = 20, Valor = 30},
                new TamanhoPizza { ID = 2, Descricao = "GRANDE", Tempo = 25, Valor = 40 }
            };
        }  
        
        public int TempoPreparo(int sabor)
        {
            var t = Tempo;
            if(sabor == 3)
            {
                Tempo += 5;
            }
            return t;
        }
    }
}

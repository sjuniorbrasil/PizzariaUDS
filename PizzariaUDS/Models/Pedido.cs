using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PizzariaUDS.Models
{
    public class Pedido
    {
        [Required]
        public int Id { get; set; }

        
        public int? SaborId { get; set; }

        
        public int TamanhoId { get; set; }
                
        public decimal ValorPizza { get; set; }

        
        public int? TempoPreparo { get; set; }

        public decimal? ValorAdicional { get; set; }

        public decimal ValorTotal { get; set; }

        public List<PedidoAdicional> Adicionais { get; set; }

    }
}

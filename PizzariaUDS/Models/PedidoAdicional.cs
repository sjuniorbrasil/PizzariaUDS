using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PizzariaUDS.Models
{
    public class PedidoAdicional
    {
        [Key, Column(Order = 0)]
        public int PedidoId { get; set; }

        [Key, Column(Order = 1)]
        public int PedidoAdicionalId { get; set; }

        public int AdicionalId { get; set; }

        public decimal? Valor { get; set; }

        public int? Tempo { get; set; }
    }
}

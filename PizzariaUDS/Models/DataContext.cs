using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaUDS.Models
{
    
    public partial class DataContext :DbContext
    {

        
        public DataContext()
                    : base(Utils.Utils.Conexao())
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();           
        }

        public virtual DbSet<Pedido> Pedidos { get; set; }

        public virtual DbSet<PedidoAdicional> Adicionais { get; set; }
    }
    
}

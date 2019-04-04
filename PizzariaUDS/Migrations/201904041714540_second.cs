namespace PizzariaUDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PedidoAdicionals", newName: "PedidoAdicional");
            RenameTable(name: "dbo.Pedidoes", newName: "Pedido");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Pedido", newName: "Pedidoes");
            RenameTable(name: "dbo.PedidoAdicional", newName: "PedidoAdicionals");
        }
    }
}

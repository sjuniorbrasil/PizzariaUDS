namespace PizzariaUDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PedidoAdicionals",
                c => new
                    {
                        PedidoId = c.Int(nullable: false),
                        PedidoAdicionalId = c.Int(nullable: false),
                        AdicionalId = c.Int(nullable: false),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        Tempo = c.Int(),
                    })
                .PrimaryKey(t => new { t.PedidoId, t.PedidoAdicionalId })
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaborId = c.Int(),
                        TamanhoId = c.Int(nullable: false),
                        ValorPizza = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoPreparo = c.Int(),
                        ValorAdicional = c.Decimal(precision: 18, scale: 2),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoAdicionals", "PedidoId", "dbo.Pedidoes");
            DropIndex("dbo.PedidoAdicionals", new[] { "PedidoId" });
            DropTable("dbo.Pedidoes");
            DropTable("dbo.PedidoAdicionals");
        }
    }
}

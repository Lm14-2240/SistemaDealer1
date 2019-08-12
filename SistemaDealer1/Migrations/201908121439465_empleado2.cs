namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empleado2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Movimientoes", new[] { "ClienteId" });
            AlterColumn("dbo.Movimientoes", "ClienteId", c => c.Int());
            CreateIndex("dbo.Movimientoes", "ClienteId");
            AddForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Movimientoes", new[] { "ClienteId" });
            AlterColumn("dbo.Movimientoes", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movimientoes", "ClienteId");
            AddForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}

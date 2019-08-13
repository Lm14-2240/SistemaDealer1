namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empleado5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Movimientoes", new[] { "ProveedorId" });
            AlterColumn("dbo.Movimientoes", "ProveedorId", c => c.Int());
            CreateIndex("dbo.Movimientoes", "ProveedorId");
            AddForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors", "ProveedorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Movimientoes", new[] { "ProveedorId" });
            AlterColumn("dbo.Movimientoes", "ProveedorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movimientoes", "ProveedorId");
            AddForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors", "ProveedorId", cascadeDelete: true);
        }
    }
}

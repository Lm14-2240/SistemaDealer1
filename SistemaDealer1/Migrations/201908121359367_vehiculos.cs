namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehiculos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculoes", "ProvedorId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehiculoes", "Proveedor_ProveedorId", c => c.Int());
            CreateIndex("dbo.Vehiculoes", "Proveedor_ProveedorId");
            AddForeignKey("dbo.Vehiculoes", "Proveedor_ProveedorId", "dbo.Proveedors", "ProveedorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "Proveedor_ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Vehiculoes", new[] { "Proveedor_ProveedorId" });
            DropColumn("dbo.Vehiculoes", "Proveedor_ProveedorId");
            DropColumn("dbo.Vehiculoes", "ProvedorId");
        }
    }
}

namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventario3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculoes", "Proveedor_ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Vehiculoes", new[] { "Proveedor_ProveedorId" });
            RenameColumn(table: "dbo.Vehiculoes", name: "Proveedor_ProveedorId", newName: "ProveedorId");
            AlterColumn("dbo.Vehiculoes", "ProveedorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehiculoes", "ProveedorId");
            AddForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors", "ProveedorId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Vehiculoes", new[] { "ProveedorId" });
            AlterColumn("dbo.Vehiculoes", "ProveedorId", c => c.Int());
            RenameColumn(table: "dbo.Vehiculoes", name: "ProveedorId", newName: "Proveedor_ProveedorId");
            CreateIndex("dbo.Vehiculoes", "Proveedor_ProveedorId");
            AddForeignKey("dbo.Vehiculoes", "Proveedor_ProveedorId", "dbo.Proveedors", "ProveedorId");
        }
    }
}

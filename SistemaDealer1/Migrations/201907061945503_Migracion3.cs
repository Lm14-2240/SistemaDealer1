namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Facturas", new[] { "VehiculoId" });
            RenameColumn(table: "dbo.Facturas", name: "VehiculoId", newName: "Vehiculo_VehiculoId");
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Estatus = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Factura_Detalle",
                c => new
                    {
                        FacturaDetalleId = c.Int(nullable: false, identity: true),
                        VehiculoId = c.Int(nullable: false),
                        FacturaId = c.Int(nullable: false),
                        PrecioUnidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaDetalleId)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.FacturaId);
            
            AddColumn("dbo.Facturas", "PrecioTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Vehiculoes", "ProveedorId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehiculoes", "FechadeEntrada", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Facturas", "Vehiculo_VehiculoId", c => c.Int());
            CreateIndex("dbo.Facturas", "Vehiculo_VehiculoId");
            CreateIndex("dbo.Vehiculoes", "ProveedorId");
            AddForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors", "ProveedorId", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "Vehiculo_VehiculoId", "dbo.Vehiculoes", "VehiculoId");
            DropColumn("dbo.Facturas", "Referencia");
            DropColumn("dbo.Facturas", "Precio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Facturas", "Referencia", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.Facturas", "Vehiculo_VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Factura_Detalle", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Factura_Detalle", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Factura_Detalle", new[] { "FacturaId" });
            DropIndex("dbo.Factura_Detalle", new[] { "VehiculoId" });
            DropIndex("dbo.Vehiculoes", new[] { "ProveedorId" });
            DropIndex("dbo.Facturas", new[] { "Vehiculo_VehiculoId" });
            AlterColumn("dbo.Facturas", "Vehiculo_VehiculoId", c => c.Int(nullable: false));
            DropColumn("dbo.Vehiculoes", "FechadeEntrada");
            DropColumn("dbo.Vehiculoes", "ProveedorId");
            DropColumn("dbo.Facturas", "PrecioTotal");
            DropTable("dbo.Factura_Detalle");
            DropTable("dbo.Proveedors");
            RenameColumn(table: "dbo.Facturas", name: "Vehiculo_VehiculoId", newName: "VehiculoId");
            CreateIndex("dbo.Facturas", "VehiculoId");
            AddForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: true);
        }
    }
}

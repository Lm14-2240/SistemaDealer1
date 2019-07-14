namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Facturas", new[] { "VehiculoId" });
            DropIndex("dbo.Reservas", new[] { "ClienteId" });
            DropIndex("dbo.Reservas", new[] { "EmpleadoId" });
            DropIndex("dbo.Reservas", new[] { "VehiculoId" });
            RenameColumn(table: "dbo.Facturas", name: "VehiculoId", newName: "Vehiculo_VehiculoId");
            CreateTable(
                "dbo.Movimientoes",
                c => new
                    {
                        MovimientoId = c.Int(nullable: false, identity: true),
                        Tipo_Movimiento = c.String(nullable: false, maxLength: 30),
                        Cantidad = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovimientoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.ProveedorId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 30),
                        Estatus = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        InventarioId = c.Int(nullable: false, identity: true),
                        CantidadExistencia = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventarioId)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId);
            
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
            AddColumn("dbo.Vehiculoes", "FechadeEntrada", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Facturas", "Vehiculo_VehiculoId", c => c.Int());
            CreateIndex("dbo.Facturas", "Vehiculo_VehiculoId");
            AddForeignKey("dbo.Facturas", "Vehiculo_VehiculoId", "dbo.Vehiculoes", "VehiculoId");
            DropColumn("dbo.Clientes", "Genero");
            DropColumn("dbo.Clientes", "EstatusCivil");
            DropColumn("dbo.Facturas", "Referencia");
            DropColumn("dbo.Facturas", "Precio");
            DropTable("dbo.Reservas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        FechaReserva = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Estatus = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ReservaId);
            
            AddColumn("dbo.Facturas", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Facturas", "Referencia", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clientes", "EstatusCivil", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clientes", "Genero", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.Facturas", "Vehiculo_VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Factura_Detalle", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Factura_Detalle", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Movimientoes", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Inventarios", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Movimientoes", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Factura_Detalle", new[] { "FacturaId" });
            DropIndex("dbo.Factura_Detalle", new[] { "VehiculoId" });
            DropIndex("dbo.Inventarios", new[] { "VehiculoId" });
            DropIndex("dbo.Movimientoes", new[] { "ClienteId" });
            DropIndex("dbo.Movimientoes", new[] { "EmpleadoId" });
            DropIndex("dbo.Movimientoes", new[] { "ProveedorId" });
            DropIndex("dbo.Movimientoes", new[] { "VehiculoId" });
            DropIndex("dbo.Facturas", new[] { "Vehiculo_VehiculoId" });
            AlterColumn("dbo.Facturas", "Vehiculo_VehiculoId", c => c.Int(nullable: false));
            DropColumn("dbo.Vehiculoes", "FechadeEntrada");
            DropColumn("dbo.Facturas", "PrecioTotal");
            DropTable("dbo.Factura_Detalle");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Movimientoes");
            RenameColumn(table: "dbo.Facturas", name: "Vehiculo_VehiculoId", newName: "VehiculoId");
            CreateIndex("dbo.Reservas", "VehiculoId");
            CreateIndex("dbo.Reservas", "EmpleadoId");
            CreateIndex("dbo.Reservas", "ClienteId");
            CreateIndex("dbo.Facturas", "VehiculoId");
            AddForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}

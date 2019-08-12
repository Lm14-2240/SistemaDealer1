namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Estatus = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        CedulaPasaporte = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 30),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Apellido = c.String(nullable: false, maxLength: 30),
                        Correo = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        MetodoPago = c.String(nullable: false, maxLength: 30),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId)
                .Index(t => t.VehiculoId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        RolId = c.Int(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 30),
                        Contraseña = c.String(nullable: false, maxLength: 20),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Apellido = c.String(nullable: false, maxLength: 30),
                        Correo = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
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
                        Estatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        VehiculoId = c.Int(nullable: false, identity: true),
                        MarcaId = c.Int(nullable: false),
                        ModeloId = c.Int(nullable: false),
                        TransmisionId = c.Int(nullable: false),
                        CombustibleId = c.Int(nullable: false),
                        Año = c.DateTime(nullable: false),
                        Color = c.String(nullable: false, maxLength: 30),
                        Puertas = c.Int(nullable: false),
                        Estatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoId)
                .ForeignKey("dbo.Combustibles", t => t.CombustibleId, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .ForeignKey("dbo.Modeloes", t => t.ModeloId, cascadeDelete: true)
                .ForeignKey("dbo.Transmisions", t => t.TransmisionId, cascadeDelete: true)
                .Index(t => t.MarcaId)
                .Index(t => t.ModeloId)
                .Index(t => t.TransmisionId)
                .Index(t => t.CombustibleId);
            
            CreateTable(
                "dbo.Combustibles",
                c => new
                    {
                        CombustibleId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CombustibleId);
            
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
                "dbo.Marcas",
                c => new
                    {
                        MarcaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.MarcaId);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        ModeloId = c.Int(nullable: false, identity: true),
                        MarcaId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ModeloId)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: false)
                .Index(t => t.MarcaId);
            
            CreateTable(
                "dbo.Transmisions",
                c => new
                    {
                        TransmisionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.TransmisionId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.RolId);
            
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
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: false)
                .Index(t => t.VehiculoId)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.Sucursals",
                c => new
                    {
                        SucursalId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        Ubicacion = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 30),
                        Correo = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.SucursalId)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sucursals", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Factura_Detalle", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Factura_Detalle", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Movimientoes", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "TransmisionId", "dbo.Transmisions");
            DropForeignKey("dbo.Vehiculoes", "ModeloId", "dbo.Modeloes");
            DropForeignKey("dbo.Vehiculoes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Inventarios", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "CombustibleId", "dbo.Combustibles");
            DropForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Movimientoes", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Sucursals", new[] { "EmpleadoId" });
            DropIndex("dbo.Factura_Detalle", new[] { "FacturaId" });
            DropIndex("dbo.Factura_Detalle", new[] { "VehiculoId" });
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            DropIndex("dbo.Inventarios", new[] { "VehiculoId" });
            DropIndex("dbo.Vehiculoes", new[] { "CombustibleId" });
            DropIndex("dbo.Vehiculoes", new[] { "TransmisionId" });
            DropIndex("dbo.Vehiculoes", new[] { "ModeloId" });
            DropIndex("dbo.Vehiculoes", new[] { "MarcaId" });
            DropIndex("dbo.Movimientoes", new[] { "ClienteId" });
            DropIndex("dbo.Movimientoes", new[] { "EmpleadoId" });
            DropIndex("dbo.Movimientoes", new[] { "ProveedorId" });
            DropIndex("dbo.Movimientoes", new[] { "VehiculoId" });
            DropIndex("dbo.Empleadoes", new[] { "RolId" });
            DropIndex("dbo.Facturas", new[] { "VehiculoId" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.Facturas", new[] { "EmpleadoId" });
            DropTable("dbo.Sucursals");
            DropTable("dbo.Factura_Detalle");
            DropTable("dbo.Rols");
            DropTable("dbo.Transmisions");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Combustibles");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Movimientoes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}

namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HolaMundo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Estatus = c.String(nullable: false, maxLength: 30),
                        FechaNacimiento = c.DateTime(nullable: false),
                        CedulaPasaporte = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 30),
                        Genero = c.String(nullable: false, maxLength: 30),
                        EstatusCivil = c.String(nullable: false, maxLength: 30),
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
                        VehiculoId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Referencia = c.String(nullable: false, maxLength: 30),
                        MetodoPago = c.String(nullable: false, maxLength: 30),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId);
            
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
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.VehiculoId);
            
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
                        CantidadExistente = c.Int(nullable: false),
                        Estatus = c.String(nullable: false, maxLength: 30),
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
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Vehiculoes", "TransmisionId", "dbo.Transmisions");
            DropForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "ModeloId", "dbo.Modeloes");
            DropForeignKey("dbo.Vehiculoes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "CombustibleId", "dbo.Combustibles");
            DropForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            DropIndex("dbo.Vehiculoes", new[] { "CombustibleId" });
            DropIndex("dbo.Vehiculoes", new[] { "TransmisionId" });
            DropIndex("dbo.Vehiculoes", new[] { "ModeloId" });
            DropIndex("dbo.Vehiculoes", new[] { "MarcaId" });
            DropIndex("dbo.Reservas", new[] { "VehiculoId" });
            DropIndex("dbo.Reservas", new[] { "EmpleadoId" });
            DropIndex("dbo.Reservas", new[] { "ClienteId" });
            DropIndex("dbo.Empleadoes", new[] { "RolId" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.Facturas", new[] { "EmpleadoId" });
            DropIndex("dbo.Facturas", new[] { "VehiculoId" });
            DropTable("dbo.Rols");
            DropTable("dbo.Transmisions");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Combustibles");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Reservas");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}

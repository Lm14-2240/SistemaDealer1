namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Reservas", new[] { "ClienteId" });
            DropIndex("dbo.Reservas", new[] { "EmpleadoId" });
            DropIndex("dbo.Reservas", new[] { "VehiculoId" });
            DropIndex("dbo.Vehiculoes", new[] { "ProveedorId" });
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
            
            DropColumn("dbo.Clientes", "Genero");
            DropColumn("dbo.Clientes", "EstatusCivil");
            DropColumn("dbo.Vehiculoes", "ProveedorId");
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
            
            AddColumn("dbo.Vehiculoes", "ProveedorId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "EstatusCivil", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clientes", "Genero", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.Movimientoes", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Inventarios", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Movimientoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Movimientoes", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Movimientoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Inventarios", new[] { "VehiculoId" });
            DropIndex("dbo.Movimientoes", new[] { "ClienteId" });
            DropIndex("dbo.Movimientoes", new[] { "EmpleadoId" });
            DropIndex("dbo.Movimientoes", new[] { "ProveedorId" });
            DropIndex("dbo.Movimientoes", new[] { "VehiculoId" });
            DropTable("dbo.Inventarios");
            DropTable("dbo.Movimientoes");
            CreateIndex("dbo.Vehiculoes", "ProveedorId");
            CreateIndex("dbo.Reservas", "VehiculoId");
            CreateIndex("dbo.Reservas", "EmpleadoId");
            CreateIndex("dbo.Reservas", "ClienteId");
            AddForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors", "ProveedorId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}

namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Vehiculoes", new[] { "ProveedorId" });
            DropIndex("dbo.Reservas", new[] { "ClienteId" });
            DropIndex("dbo.Reservas", new[] { "EmpleadoId" });
            DropIndex("dbo.Reservas", new[] { "VehiculoId" });
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
            
            AddColumn("dbo.Vehiculoes", "CantidadExistente", c => c.Int(nullable: false));
            AddColumn("dbo.Vehiculoes", "Estatus", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Proveedors", "Telefono", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Vehiculoes", "Año", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vehiculoes", "ProveedorId");
            DropColumn("dbo.Proveedors", "Descripcion");
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
            
            AddColumn("dbo.Proveedors", "Descripcion", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Vehiculoes", "ProveedorId", c => c.Int(nullable: false));
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
            AlterColumn("dbo.Vehiculoes", "Año", c => c.String(nullable: false));
            DropColumn("dbo.Proveedors", "Telefono");
            DropColumn("dbo.Vehiculoes", "Estatus");
            DropColumn("dbo.Vehiculoes", "CantidadExistente");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Movimientoes");
            CreateIndex("dbo.Reservas", "VehiculoId");
            CreateIndex("dbo.Reservas", "EmpleadoId");
            CreateIndex("dbo.Reservas", "ClienteId");
            CreateIndex("dbo.Vehiculoes", "ProveedorId");
            AddForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.Vehiculoes", "ProveedorId", "dbo.Proveedors", "ProveedorId", cascadeDelete: true);
        }
    }
}

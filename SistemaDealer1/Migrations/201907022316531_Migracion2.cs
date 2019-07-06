namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion2 : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Sucursals", new[] { "EmpleadoId" });
            DropTable("dbo.Sucursals");
        }
    }
}

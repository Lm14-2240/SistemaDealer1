namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Vehiculo_VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Facturas", new[] { "Vehiculo_VehiculoId" });
            RenameColumn(table: "dbo.Facturas", name: "Vehiculo_VehiculoId", newName: "VehiculoId");
            AlterColumn("dbo.Facturas", "VehiculoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "VehiculoId");
            AddForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Facturas", new[] { "VehiculoId" });
            AlterColumn("dbo.Facturas", "VehiculoId", c => c.Int());
            RenameColumn(table: "dbo.Facturas", name: "VehiculoId", newName: "Vehiculo_VehiculoId");
            CreateIndex("dbo.Facturas", "Vehiculo_VehiculoId");
            AddForeignKey("dbo.Facturas", "Vehiculo_VehiculoId", "dbo.Vehiculoes", "VehiculoId");
        }
    }
}

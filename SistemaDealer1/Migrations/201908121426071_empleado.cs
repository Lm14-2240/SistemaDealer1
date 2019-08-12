namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empleado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculoes", "EmpleadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehiculoes", "EmpleadoId");
            AddForeignKey("dbo.Vehiculoes", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "EmpleadoId", "dbo.Empleadoes");
            DropIndex("dbo.Vehiculoes", new[] { "EmpleadoId" });
            DropColumn("dbo.Vehiculoes", "EmpleadoId");
        }
    }
}

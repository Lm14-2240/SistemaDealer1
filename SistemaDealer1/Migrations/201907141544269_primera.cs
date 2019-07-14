namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehiculoes", "Año", c => c.String(nullable: false));
            DropColumn("dbo.Vehiculoes", "CantidadExistente");
            DropColumn("dbo.Vehiculoes", "Estatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculoes", "Estatus", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Vehiculoes", "CantidadExistente", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehiculoes", "Año", c => c.DateTime(nullable: false));
        }
    }
}

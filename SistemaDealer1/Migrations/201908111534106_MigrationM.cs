namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationM : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehiculoes", "CantidadExistente");
            DropColumn("dbo.Vehiculoes", "FechadeEntrada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculoes", "FechadeEntrada", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehiculoes", "CantidadExistente", c => c.Int(nullable: false));
        }
    }
}

namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehiculoes", "CantidadExistente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculoes", "CantidadExistente", c => c.Int(nullable: false));
        }
    }
}

namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehiculoes", "FechadeEntrada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculoes", "FechadeEntrada", c => c.DateTime(nullable: false));
        }
    }
}

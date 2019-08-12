namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventario2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehiculoes", "ProvedorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculoes", "ProvedorId", c => c.Int(nullable: false));
        }
    }
}

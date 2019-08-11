namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proveedors", "Estatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehiculoes", "Estatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehiculoes", "Estatus", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Proveedors", "Estatus", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

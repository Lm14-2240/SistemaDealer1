namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empleado4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "PrecioUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "PrecioUnitario");
        }
    }
}

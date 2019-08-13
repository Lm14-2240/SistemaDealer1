namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class metodosDePago : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "MetodoPago", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facturas", "MetodoPago", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

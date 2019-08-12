namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventarios", "MarcaId", c => c.Int(nullable: false));
            AddColumn("dbo.Inventarios", "ModeloId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventarios", "ModeloId");
            DropColumn("dbo.Inventarios", "MarcaId");
        }
    }
}

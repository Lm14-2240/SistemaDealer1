namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizarClientes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Genero");
            DropColumn("dbo.Clientes", "EstatusCivil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "EstatusCivil", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clientes", "Genero", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

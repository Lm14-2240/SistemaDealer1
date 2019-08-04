namespace SistemaDealer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clientes", "Apellido", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Empleadoes", "Nombre", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Empleadoes", "Apellido", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Movimientoes", "Tipo_Movimiento", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Movimientoes", "TipoMovimiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movimientoes", "TipoMovimiento", c => c.String(nullable: false));
            DropColumn("dbo.Movimientoes", "Tipo_Movimiento");
            DropColumn("dbo.Empleadoes", "Apellido");
            DropColumn("dbo.Empleadoes", "Nombre");
            DropColumn("dbo.Clientes", "Apellido");
            DropColumn("dbo.Clientes", "Nombre");
        }
    }
}

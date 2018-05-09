namespace EscoTestGaston.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionAuto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auto", "Marca", c => c.String());
            AddColumn("dbo.Auto", "Anio", c => c.Int(nullable: false));
            AddColumn("dbo.Auto", "Patente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auto", "Patente");
            DropColumn("dbo.Auto", "Anio");
            DropColumn("dbo.Auto", "Marca");
        }
    }
}

namespace EscoTestGaston.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServicioID = c.Int(nullable: false),
                        PropietarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Propietario", t => t.PropietarioID, cascadeDelete: true)
                .ForeignKey("dbo.Servicio", t => t.ServicioID, cascadeDelete: true)
                .Index(t => t.ServicioID)
                .Index(t => t.PropietarioID);
            
            CreateTable(
                "dbo.Propietario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Apellido = c.String(),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoServicio = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auto", "ServicioID", "dbo.Servicio");
            DropForeignKey("dbo.Auto", "PropietarioID", "dbo.Propietario");
            DropIndex("dbo.Auto", new[] { "PropietarioID" });
            DropIndex("dbo.Auto", new[] { "ServicioID" });
            DropTable("dbo.Servicio");
            DropTable("dbo.Propietario");
            DropTable("dbo.Auto");
        }
    }
}

namespace ElImportador.AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreMarca = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Costo = c.Double(nullable: false),
                        PrecioNacional = c.Double(nullable: false),
                        MarcaId = c.Int(),
                        Modelo = c.String(),
                        MargenGanancia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .Index(t => t.MarcaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Productos", new[] { "MarcaId" });
            DropTable("dbo.Productos");
            DropTable("dbo.Marcas");
        }
    }
}

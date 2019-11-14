namespace ChatonsCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutChaton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chatons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        DateDeNaissance = c.DateTime(nullable: false),
                        Sterilise = c.Boolean(nullable: false),
                        Categorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .Index(t => t.Categorie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chatons", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Chatons", new[] { "Categorie_Id" });
            DropTable("dbo.Chatons");
        }
    }
}

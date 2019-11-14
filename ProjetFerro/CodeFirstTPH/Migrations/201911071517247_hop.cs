namespace CodeFirstTPH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Male = c.Boolean(nullable: false),
                        Femelle = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 50),
                        Espece = c.String(nullable: false, maxLength: 50),
                        AquatiqueStrict = c.Boolean(),
                        ADesDents = c.Boolean(),
                        SaitVoler = c.Boolean(),
                        DateDeNaissance = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}

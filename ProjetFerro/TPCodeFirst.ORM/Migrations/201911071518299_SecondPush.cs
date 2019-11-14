namespace TPCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondPush : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentGrades", "Person_PersonID", c => c.Int());
            CreateIndex("dbo.StudentGrades", "Person_PersonID");
            AddForeignKey("dbo.StudentGrades", "Person_PersonID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "Person_PersonID", "dbo.People");
            DropIndex("dbo.StudentGrades", new[] { "Person_PersonID" });
            DropColumn("dbo.StudentGrades", "Person_PersonID");
        }
    }
}

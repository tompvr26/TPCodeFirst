namespace TPCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstPush : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Credits = c.Int(nullable: false),
                        Departement_DepartementID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departements", t => t.Departement_DepartementID)
                .Index(t => t.Departement_DepartementID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        HireDate = c.DateTime(),
                        EnrollmentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        Administrator = c.Int(),
                    })
                .PrimaryKey(t => t.DepartementID);
            
            CreateTable(
                "dbo.PersonCourses",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Course_Id })
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Departement_DepartementID", "dbo.Departements");
            DropForeignKey("dbo.StudentGrades", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.PersonCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.PersonCourses", "Person_PersonID", "dbo.People");
            DropIndex("dbo.PersonCourses", new[] { "Course_Id" });
            DropIndex("dbo.PersonCourses", new[] { "Person_PersonID" });
            DropIndex("dbo.StudentGrades", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Departement_DepartementID" });
            DropTable("dbo.PersonCourses");
            DropTable("dbo.Departements");
            DropTable("dbo.StudentGrades");
            DropTable("dbo.People");
            DropTable("dbo.Courses");
        }
    }
}

namespace ItLabs.FinkInformator.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StructuredProgramming : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 30),
                        CourseDescription = c.String(maxLength: 2000),
                        Semester = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}

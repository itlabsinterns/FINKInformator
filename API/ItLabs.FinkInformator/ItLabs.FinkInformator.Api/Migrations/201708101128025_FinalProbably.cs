namespace ItLabs.FinkInformator.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalProbably : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoursesPrerequisites",
                c => new
                    {
                        CoursesPrerequisitesId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        PrerequisiteId = c.Int(nullable: false),
                        Course_CourseId = c.Int(),
                        Prerequisite_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.CoursesPrerequisitesId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Courses", t => t.Prerequisite_CourseId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Prerequisite_CourseId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.ProgramsCourses",
                c => new
                    {
                        ProgramsCoursesId = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        IsMandatory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramsCoursesId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramsCourses", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramsCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CoursesPrerequisites", "Prerequisite_CourseId", "dbo.Courses");
            DropForeignKey("dbo.CoursesPrerequisites", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.ProgramsCourses", new[] { "CourseId" });
            DropIndex("dbo.ProgramsCourses", new[] { "ProgramId" });
            DropIndex("dbo.CoursesPrerequisites", new[] { "Prerequisite_CourseId" });
            DropIndex("dbo.CoursesPrerequisites", new[] { "Course_CourseId" });
            DropTable("dbo.ProgramsCourses");
            DropTable("dbo.Programs");
            DropTable("dbo.CoursesPrerequisites");
        }
    }
}

namespace ItLabs.FinkInformator.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalIGuess : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CoursesPrerequisites", "CourseId");
            DropColumn("dbo.CoursesPrerequisites", "PrerequisiteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoursesPrerequisites", "PrerequisiteId", c => c.Int(nullable: false));
            AddColumn("dbo.CoursesPrerequisites", "CourseId", c => c.Int(nullable: false));
        }
    }
}

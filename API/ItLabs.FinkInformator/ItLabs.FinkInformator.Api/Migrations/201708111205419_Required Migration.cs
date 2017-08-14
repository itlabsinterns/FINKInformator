namespace ItLabs.FinkInformator.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}

namespace WedLab345.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "lecturerId" });
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Courses", "LecturerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "LecturerId" });
            DropColumn("dbo.AspNetUsers", "Name");
            CreateIndex("dbo.Courses", "lecturerId");
        }
    }
}

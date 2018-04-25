namespace FluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCourseLevelToEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Level", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Level", c => c.Int(nullable: false));
        }
    }
}

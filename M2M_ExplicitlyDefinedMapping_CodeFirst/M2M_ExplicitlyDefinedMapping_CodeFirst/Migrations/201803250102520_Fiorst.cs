namespace M2M_ExplicitlyDefinedMapping_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fiorst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        RequirementId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequirementId);
            
            CreateTable(
                "dbo.RequirementTestMaps",
                c => new
                    {
                        RequirementId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequirementId, t.TestId })
                .ForeignKey("dbo.Requirements", t => t.RequirementId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.RequirementId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequirementTestMaps", "TestId", "dbo.Tests");
            DropForeignKey("dbo.RequirementTestMaps", "RequirementId", "dbo.Requirements");
            DropIndex("dbo.RequirementTestMaps", new[] { "TestId" });
            DropIndex("dbo.RequirementTestMaps", new[] { "RequirementId" });
            DropTable("dbo.Tests");
            DropTable("dbo.RequirementTestMaps");
            DropTable("dbo.Requirements");
        }
    }
}

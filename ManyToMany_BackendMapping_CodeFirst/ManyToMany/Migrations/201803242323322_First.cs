namespace ManyToMany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
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
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.QALab_Mapping",
                c => new
                    {
                        TestRefId = c.Int(nullable: false),
                        RequirementRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestRefId, t.RequirementRefId })
                .ForeignKey("dbo.Tests", t => t.TestRefId, cascadeDelete: true)
                .ForeignKey("dbo.Requirements", t => t.RequirementRefId, cascadeDelete: true)
                .Index(t => t.TestRefId)
                .Index(t => t.RequirementRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QALab_Mapping", "RequirementRefId", "dbo.Requirements");
            DropForeignKey("dbo.QALab_Mapping", "TestRefId", "dbo.Tests");
            DropIndex("dbo.QALab_Mapping", new[] { "RequirementRefId" });
            DropIndex("dbo.QALab_Mapping", new[] { "TestRefId" });
            DropTable("dbo.QALab_Mapping");
            DropTable("dbo.Tests");
            DropTable("dbo.Requirements");
        }
    }
}

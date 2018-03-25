namespace ManyToMany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedManyToMany : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QALab_Mapping", newName: "QALabTest_Map");
            RenameColumn(table: "dbo.QALabTest_Map", name: "TestRefId", newName: "TestId");
            RenameColumn(table: "dbo.QALabTest_Map", name: "RequirementRefId", newName: "RequirementId");
            RenameIndex(table: "dbo.QALabTest_Map", name: "IX_TestRefId", newName: "IX_TestId");
            RenameIndex(table: "dbo.QALabTest_Map", name: "IX_RequirementRefId", newName: "IX_RequirementId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QALabTest_Map", name: "IX_RequirementId", newName: "IX_RequirementRefId");
            RenameIndex(table: "dbo.QALabTest_Map", name: "IX_TestId", newName: "IX_TestRefId");
            RenameColumn(table: "dbo.QALabTest_Map", name: "RequirementId", newName: "RequirementRefId");
            RenameColumn(table: "dbo.QALabTest_Map", name: "TestId", newName: "TestRefId");
            RenameTable(name: "dbo.QALabTest_Map", newName: "QALab_Mapping");
        }
    }
}

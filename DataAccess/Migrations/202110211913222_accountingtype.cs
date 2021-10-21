namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountingtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountingTypes", "TypeTitle", c => c.String(nullable: false));
            CreateIndex("dbo.Accountings", "Costomerid");
            CreateIndex("dbo.Accountings", "Typeid");
            AddForeignKey("dbo.Accountings", "Typeid", "dbo.AccountingTypes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Accountings", "Costomerid", "dbo.Costomers", "CostomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accountings", "Costomerid", "dbo.Costomers");
            DropForeignKey("dbo.Accountings", "Typeid", "dbo.AccountingTypes");
            DropIndex("dbo.Accountings", new[] { "Typeid" });
            DropIndex("dbo.Accountings", new[] { "Costomerid" });
            AlterColumn("dbo.AccountingTypes", "TypeTitle", c => c.String());
        }
    }
}

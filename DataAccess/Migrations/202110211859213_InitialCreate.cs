namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Costomerid = c.Int(nullable: false),
                        Typeid = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Discraption = c.String(),
                        DataTitle = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AccountingTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TypeTitle = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Costomers",
                c => new
                    {
                        CostomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        E_Post = c.String(),
                        Mobile = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        PicAddress = c.String(),
                    })
                .PrimaryKey(t => t.CostomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Costomers");
            DropTable("dbo.AccountingTypes");
            DropTable("dbo.Accountings");
        }
    }
}

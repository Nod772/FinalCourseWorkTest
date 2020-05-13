namespace BaseTestLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TextAnswer = c.String(),
                        isTrueAnswer = c.Boolean(nullable: false),
                        Question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .Index(t => t.Question_ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TextQuestion = c.String(),
                        Test_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.Test_ID)
                .Index(t => t.Test_ID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Teasher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teashers", t => t.Teasher_ID)
                .Index(t => t.Teasher_ID);
            
            CreateTable(
                "dbo.Teashers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "Teasher_ID", "dbo.Teashers");
            DropForeignKey("dbo.Questions", "Test_ID", "dbo.Tests");
            DropForeignKey("dbo.AnswerOptions", "Question_ID", "dbo.Questions");
            DropIndex("dbo.Tests", new[] { "Teasher_ID" });
            DropIndex("dbo.Questions", new[] { "Test_ID" });
            DropIndex("dbo.AnswerOptions", new[] { "Question_ID" });
            DropTable("dbo.Teashers");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.AnswerOptions");
        }
    }
}

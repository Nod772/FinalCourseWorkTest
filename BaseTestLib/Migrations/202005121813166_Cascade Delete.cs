namespace BaseTestLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerOptions", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Test_ID", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Teasher_ID", "dbo.Teashers");
            DropIndex("dbo.AnswerOptions", new[] { "Question_ID" });
            DropIndex("dbo.Questions", new[] { "Test_ID" });
            DropIndex("dbo.Tests", new[] { "Teasher_ID" });
            AlterColumn("dbo.AnswerOptions", "Question_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Test_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tests", "Teasher_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.AnswerOptions", "Question_ID");
            CreateIndex("dbo.Questions", "Test_ID");
            CreateIndex("dbo.Tests", "Teasher_ID");
            AddForeignKey("dbo.AnswerOptions", "Question_ID", "dbo.Questions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Test_ID", "dbo.Tests", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "Teasher_ID", "dbo.Teashers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "Teasher_ID", "dbo.Teashers");
            DropForeignKey("dbo.Questions", "Test_ID", "dbo.Tests");
            DropForeignKey("dbo.AnswerOptions", "Question_ID", "dbo.Questions");
            DropIndex("dbo.Tests", new[] { "Teasher_ID" });
            DropIndex("dbo.Questions", new[] { "Test_ID" });
            DropIndex("dbo.AnswerOptions", new[] { "Question_ID" });
            AlterColumn("dbo.Tests", "Teasher_ID", c => c.Int());
            AlterColumn("dbo.Questions", "Test_ID", c => c.Int());
            AlterColumn("dbo.AnswerOptions", "Question_ID", c => c.Int());
            CreateIndex("dbo.Tests", "Teasher_ID");
            CreateIndex("dbo.Questions", "Test_ID");
            CreateIndex("dbo.AnswerOptions", "Question_ID");
            AddForeignKey("dbo.Tests", "Teasher_ID", "dbo.Teashers", "ID");
            AddForeignKey("dbo.Questions", "Test_ID", "dbo.Tests", "ID");
            AddForeignKey("dbo.AnswerOptions", "Question_ID", "dbo.Questions", "ID");
        }
    }
}

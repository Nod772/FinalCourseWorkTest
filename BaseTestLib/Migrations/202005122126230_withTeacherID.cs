namespace BaseTestLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withTeacherID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tests", name: "Teasher_ID", newName: "TeacherID");
            RenameIndex(table: "dbo.Tests", name: "IX_Teasher_ID", newName: "IX_TeacherID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tests", name: "IX_TeacherID", newName: "IX_Teasher_ID");
            RenameColumn(table: "dbo.Tests", name: "TeacherID", newName: "Teasher_ID");
        }
    }
}

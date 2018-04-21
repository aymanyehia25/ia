namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Professors", "UserID", "dbo.Users");
            DropIndex("dbo.Professors", new[] { "UserID" });
            DropColumn("dbo.Professors", "UserID");
            DropColumn("dbo.Projects", "DeptID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "DeptID", c => c.Int(nullable: false));
            AddColumn("dbo.Professors", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Professors", "UserID");
            AddForeignKey("dbo.Professors", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}

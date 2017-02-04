namespace Zensar.Core.DBEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZensarInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubTitle = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Summary = c.String(),
                        Body = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}

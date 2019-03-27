namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        IsDone = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Lists", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ListId", "dbo.Lists");
            DropIndex("dbo.Tasks", new[] { "ListId" });
            DropTable("dbo.Notes");
            DropTable("dbo.Tasks");
            DropTable("dbo.Lists");
        }
    }
}

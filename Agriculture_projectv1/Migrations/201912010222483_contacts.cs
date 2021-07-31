namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Title = c.String(),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.CrossTypes", "Contact_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CrossTypes", "Contact_id");
            AddForeignKey("dbo.CrossTypes", "Contact_id", "dbo.Contacts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CrossTypes", "Contact_id", "dbo.Contacts");
            DropIndex("dbo.CrossTypes", new[] { "Contact_id" });
            DropColumn("dbo.CrossTypes", "Contact_id");
            DropTable("dbo.Contacts");
        }
    }
}

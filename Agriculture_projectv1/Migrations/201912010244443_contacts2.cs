namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacts2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CrossTypes", "Contact_id", "dbo.Contacts");
            DropIndex("dbo.CrossTypes", new[] { "Contact_id" });
            DropColumn("dbo.CrossTypes", "Contact_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CrossTypes", "Contact_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CrossTypes", "Contact_id");
            AddForeignKey("dbo.CrossTypes", "Contact_id", "dbo.Contacts", "id");
        }
    }
}

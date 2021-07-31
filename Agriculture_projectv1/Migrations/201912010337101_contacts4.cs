namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacts4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Contacts", "Name", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "Message", c => c.String());
            AddPrimaryKey("dbo.Contacts", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Contacts", "id");
        }
    }
}

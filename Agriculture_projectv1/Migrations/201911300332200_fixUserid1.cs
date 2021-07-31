namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixUserid1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Consultes", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultes", "ApplicationUserId", c => c.Int(nullable: false));
        }
    }
}

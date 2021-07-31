namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Componies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Fertilizers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Governorates", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SoilTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SoilTypes", "Name", c => c.String());
            AlterColumn("dbo.Governorates", "Name", c => c.String());
            AlterColumn("dbo.Fertilizers", "Name", c => c.String());
            AlterColumn("dbo.Componies", "Name", c => c.String());
        }
    }
}

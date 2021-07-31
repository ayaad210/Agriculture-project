namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FertilizerConsultes", newName: "ConsulteFertilizers");
            DropPrimaryKey("dbo.ConsulteFertilizers");
            AddPrimaryKey("dbo.ConsulteFertilizers", new[] { "Consulte_Id", "Fertilizer_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ConsulteFertilizers");
            AddPrimaryKey("dbo.ConsulteFertilizers", new[] { "Fertilizer_id", "Consulte_Id" });
            RenameTable(name: "dbo.ConsulteFertilizers", newName: "FertilizerConsultes");
        }
    }
}

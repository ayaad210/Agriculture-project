namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compTest : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ConsulteFertilizers", newName: "FertilizerConsultes");
            RenameTable(name: "dbo.CrossTypeConsultes", newName: "ConsulteCrossTypes");
            RenameTable(name: "dbo.ComponyCrossTypes", newName: "CrossTypeComponies");
            DropPrimaryKey("dbo.FertilizerConsultes");
            DropPrimaryKey("dbo.ConsulteCrossTypes");
            DropPrimaryKey("dbo.CrossTypeComponies");
            AddPrimaryKey("dbo.FertilizerConsultes", new[] { "Fertilizer_id", "Consulte_Id" });
            AddPrimaryKey("dbo.ConsulteCrossTypes", new[] { "Consulte_Id", "CrossType_id" });
            AddPrimaryKey("dbo.CrossTypeComponies", new[] { "CrossType_id", "Compony_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CrossTypeComponies");
            DropPrimaryKey("dbo.ConsulteCrossTypes");
            DropPrimaryKey("dbo.FertilizerConsultes");
            AddPrimaryKey("dbo.CrossTypeComponies", new[] { "Compony_id", "CrossType_id" });
            AddPrimaryKey("dbo.ConsulteCrossTypes", new[] { "CrossType_id", "Consulte_Id" });
            AddPrimaryKey("dbo.FertilizerConsultes", new[] { "Consulte_Id", "Fertilizer_id" });
            RenameTable(name: "dbo.CrossTypeComponies", newName: "ComponyCrossTypes");
            RenameTable(name: "dbo.ConsulteCrossTypes", newName: "CrossTypeConsultes");
            RenameTable(name: "dbo.FertilizerConsultes", newName: "ConsulteFertilizers");
        }
    }
}

namespace Agriculture_projectv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Consultes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        SoilTypeId = c.Int(nullable: false),
                        GoverorenatId = c.Int(nullable: false),
                        AreaOfSoil = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        Response = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Governorate_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Governorates", t => t.Governorate_id)
                .ForeignKey("dbo.SoilTypes", t => t.SoilTypeId, cascadeDelete: true)
                .Index(t => t.SoilTypeId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Governorate_id);
            
            CreateTable(
                "dbo.CrossTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                        seasons = c.String(),
                        Duration = c.Decimal(precision: 18, scale: 2),
                        Pesticidesdates = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Componies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Link = c.String(),
                        Notes = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Fertilizers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Governorates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SoilTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ComponyCrossTypes",
                c => new
                    {
                        Compony_id = c.Int(nullable: false),
                        CrossType_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Compony_id, t.CrossType_id })
                .ForeignKey("dbo.Componies", t => t.Compony_id, cascadeDelete: true)
                .ForeignKey("dbo.CrossTypes", t => t.CrossType_id, cascadeDelete: true)
                .Index(t => t.Compony_id)
                .Index(t => t.CrossType_id);
            
            CreateTable(
                "dbo.CrossTypeConsultes",
                c => new
                    {
                        CrossType_id = c.Int(nullable: false),
                        Consulte_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CrossType_id, t.Consulte_Id })
                .ForeignKey("dbo.CrossTypes", t => t.CrossType_id, cascadeDelete: true)
                .ForeignKey("dbo.Consultes", t => t.Consulte_Id, cascadeDelete: true)
                .Index(t => t.CrossType_id)
                .Index(t => t.Consulte_Id);
            
            CreateTable(
                "dbo.FertilizerConsultes",
                c => new
                    {
                        Fertilizer_id = c.Int(nullable: false),
                        Consulte_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fertilizer_id, t.Consulte_Id })
                .ForeignKey("dbo.Fertilizers", t => t.Fertilizer_id, cascadeDelete: true)
                .ForeignKey("dbo.Consultes", t => t.Consulte_Id, cascadeDelete: true)
                .Index(t => t.Fertilizer_id)
                .Index(t => t.Consulte_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Consultes", "SoilTypeId", "dbo.SoilTypes");
            DropForeignKey("dbo.Consultes", "Governorate_id", "dbo.Governorates");
            DropForeignKey("dbo.FertilizerConsultes", "Consulte_Id", "dbo.Consultes");
            DropForeignKey("dbo.FertilizerConsultes", "Fertilizer_id", "dbo.Fertilizers");
            DropForeignKey("dbo.CrossTypeConsultes", "Consulte_Id", "dbo.Consultes");
            DropForeignKey("dbo.CrossTypeConsultes", "CrossType_id", "dbo.CrossTypes");
            DropForeignKey("dbo.ComponyCrossTypes", "CrossType_id", "dbo.CrossTypes");
            DropForeignKey("dbo.ComponyCrossTypes", "Compony_id", "dbo.Componies");
            DropForeignKey("dbo.Consultes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.FertilizerConsultes", new[] { "Consulte_Id" });
            DropIndex("dbo.FertilizerConsultes", new[] { "Fertilizer_id" });
            DropIndex("dbo.CrossTypeConsultes", new[] { "Consulte_Id" });
            DropIndex("dbo.CrossTypeConsultes", new[] { "CrossType_id" });
            DropIndex("dbo.ComponyCrossTypes", new[] { "CrossType_id" });
            DropIndex("dbo.ComponyCrossTypes", new[] { "Compony_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Consultes", new[] { "Governorate_id" });
            DropIndex("dbo.Consultes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Consultes", new[] { "SoilTypeId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.FertilizerConsultes");
            DropTable("dbo.CrossTypeConsultes");
            DropTable("dbo.ComponyCrossTypes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.SoilTypes");
            DropTable("dbo.Governorates");
            DropTable("dbo.Fertilizers");
            DropTable("dbo.Componies");
            DropTable("dbo.CrossTypes");
            DropTable("dbo.Consultes");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}

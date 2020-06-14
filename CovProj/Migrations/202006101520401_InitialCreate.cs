namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Healties",
                c => new
                    {
                        HealthyId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.HealthyId);
            
            CreateTable(
                "dbo.Peoples",
                c => new
                    {
                        PeoplesId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Identification = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        City = c.String(nullable: false),
                        Diagnosed = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Healty_HealthyId = c.Int(),
                        Isolated_IsolatedId = c.Int(),
                        Recovering_RecoveringId = c.Int(),
                        Sick_SickId = c.Int(),
                    })
                .PrimaryKey(t => t.PeoplesId)
                .ForeignKey("dbo.Healties", t => t.Healty_HealthyId)
                .ForeignKey("dbo.Isolateds", t => t.Isolated_IsolatedId)
                .ForeignKey("dbo.Recoverings", t => t.Recovering_RecoveringId)
                .ForeignKey("dbo.Sicks", t => t.Sick_SickId)
                .Index(t => t.Healty_HealthyId)
                .Index(t => t.Isolated_IsolatedId)
                .Index(t => t.Recovering_RecoveringId)
                .Index(t => t.Sick_SickId);
            
            CreateTable(
                "dbo.InfecPlaces",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Sick_SickId = c.Int(),
                    })
                .PrimaryKey(t => t.PlaceId)
                .ForeignKey("dbo.Sicks", t => t.Sick_SickId)
                .Index(t => t.Sick_SickId);
            
            CreateTable(
                "dbo.Isolateds",
                c => new
                    {
                        IsolatedId = c.Int(nullable: false, identity: true),
                        PlaceOfIsolation = c.String(),
                    })
                .PrimaryKey(t => t.IsolatedId);
            
            CreateTable(
                "dbo.Recoverings",
                c => new
                    {
                        RecoveringId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RecoveringId);
            
            CreateTable(
                "dbo.Sicks",
                c => new
                    {
                        SickId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SickId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InfecPlaces", "Sick_SickId", "dbo.Sicks");
            DropForeignKey("dbo.Peoples", "Sick_SickId", "dbo.Sicks");
            DropForeignKey("dbo.Peoples", "Recovering_RecoveringId", "dbo.Recoverings");
            DropForeignKey("dbo.Peoples", "Isolated_IsolatedId", "dbo.Isolateds");
            DropForeignKey("dbo.Peoples", "Healty_HealthyId", "dbo.Healties");
            DropIndex("dbo.InfecPlaces", new[] { "Sick_SickId" });
            DropIndex("dbo.Peoples", new[] { "Sick_SickId" });
            DropIndex("dbo.Peoples", new[] { "Recovering_RecoveringId" });
            DropIndex("dbo.Peoples", new[] { "Isolated_IsolatedId" });
            DropIndex("dbo.Peoples", new[] { "Healty_HealthyId" });
            DropTable("dbo.Sicks");
            DropTable("dbo.Recoverings");
            DropTable("dbo.Isolateds");
            DropTable("dbo.InfecPlaces");
            DropTable("dbo.Peoples");
            DropTable("dbo.Healties");
        }
    }
}

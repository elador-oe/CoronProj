namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sicks", "PlaceId", c => c.Int(nullable: false));
            AddColumn("dbo.Sicks", "places_PlaceId", c => c.Int());
            CreateIndex("dbo.Sicks", "places_PlaceId");
            AddForeignKey("dbo.Sicks", "places_PlaceId", "dbo.InfecPlaces", "PlaceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sicks", "places_PlaceId", "dbo.InfecPlaces");
            DropIndex("dbo.Sicks", new[] { "places_PlaceId" });
            DropColumn("dbo.Sicks", "places_PlaceId");
            DropColumn("dbo.Sicks", "PlaceId");
        }
    }
}

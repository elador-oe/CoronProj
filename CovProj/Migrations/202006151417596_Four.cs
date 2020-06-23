namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sicks", "PlaceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sicks", "PlaceId");
        }
    }
}

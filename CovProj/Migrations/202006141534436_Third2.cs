namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sicks", "PeoplesId", c => c.Int(nullable: false));
            DropColumn("dbo.Sicks", "PlaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sicks", "PlaceId", c => c.Int(nullable: false));
            DropColumn("dbo.Sicks", "PeoplesId");
        }
    }
}

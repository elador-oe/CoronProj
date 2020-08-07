namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AviChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sicks", "Place", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sicks", "Place");
        }
    }
}

namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peoples", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peoples", "Password");
        }
    }
}

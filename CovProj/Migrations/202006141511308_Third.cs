namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Peoples", "Diagnosed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peoples", "Diagnosed", c => c.Boolean(nullable: false));
        }
    }
}

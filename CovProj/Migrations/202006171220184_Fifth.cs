namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Peoples", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peoples", "Password", c => c.String(nullable: false));
        }
    }
}

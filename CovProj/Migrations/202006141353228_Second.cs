namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Recoverings", name: "peoples_PeoplesId", newName: "people_PeoplesId");
            RenameIndex(table: "dbo.Recoverings", name: "IX_peoples_PeoplesId", newName: "IX_people_PeoplesId");
            AddColumn("dbo.Recoverings", "PeoplesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recoverings", "PeoplesId");
            RenameIndex(table: "dbo.Recoverings", name: "IX_people_PeoplesId", newName: "IX_peoples_PeoplesId");
            RenameColumn(table: "dbo.Recoverings", name: "people_PeoplesId", newName: "peoples_PeoplesId");
        }
    }
}

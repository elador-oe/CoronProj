namespace CovProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Healties", "peoples_PeoplesId", c => c.Int());
            AddColumn("dbo.Isolateds", "peoples_PeoplesId", c => c.Int());
            AddColumn("dbo.Recoverings", "peoples_PeoplesId", c => c.Int());
            AddColumn("dbo.Sicks", "peoples_PeoplesId", c => c.Int());
            CreateIndex("dbo.Healties", "peoples_PeoplesId");
            CreateIndex("dbo.Isolateds", "peoples_PeoplesId");
            CreateIndex("dbo.Recoverings", "peoples_PeoplesId");
            CreateIndex("dbo.Sicks", "peoples_PeoplesId");
            AddForeignKey("dbo.Healties", "peoples_PeoplesId", "dbo.Peoples", "PeoplesId");
            AddForeignKey("dbo.Isolateds", "peoples_PeoplesId", "dbo.Peoples", "PeoplesId");
            AddForeignKey("dbo.Recoverings", "peoples_PeoplesId", "dbo.Peoples", "PeoplesId");
            AddForeignKey("dbo.Sicks", "peoples_PeoplesId", "dbo.Peoples", "PeoplesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sicks", "peoples_PeoplesId", "dbo.Peoples");
            DropForeignKey("dbo.Recoverings", "peoples_PeoplesId", "dbo.Peoples");
            DropForeignKey("dbo.Isolateds", "peoples_PeoplesId", "dbo.Peoples");
            DropForeignKey("dbo.Healties", "peoples_PeoplesId", "dbo.Peoples");
            DropIndex("dbo.Sicks", new[] { "peoples_PeoplesId" });
            DropIndex("dbo.Recoverings", new[] { "peoples_PeoplesId" });
            DropIndex("dbo.Isolateds", new[] { "peoples_PeoplesId" });
            DropIndex("dbo.Healties", new[] { "peoples_PeoplesId" });
            DropColumn("dbo.Sicks", "peoples_PeoplesId");
            DropColumn("dbo.Recoverings", "peoples_PeoplesId");
            DropColumn("dbo.Isolateds", "peoples_PeoplesId");
            DropColumn("dbo.Healties", "peoples_PeoplesId");
        }
    }
}

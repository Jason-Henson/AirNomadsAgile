namespace AirNomadsAgile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplifiedShowTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        RatingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RatingId);
            
            DropColumn("dbo.Movies", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropIndex("dbo.Shows", new[] { "RatingId" });
            DropTable("dbo.Shows");
        }
    }
}

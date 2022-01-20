namespace AirNomadsAgile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRatingToMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "RatingId", c => c.Int());
            CreateIndex("dbo.Movies", "RatingId");
            AddForeignKey("dbo.Movies", "RatingId", "dbo.Ratings", "Id");
            DropColumn("dbo.Movies", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Rating", c => c.Double(nullable: false));
            DropForeignKey("dbo.Movies", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Movies", new[] { "RatingId" });
            DropColumn("dbo.Movies", "RatingId");
            DropTable("dbo.Ratings");
        }
    }
}

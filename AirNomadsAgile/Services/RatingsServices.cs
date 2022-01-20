using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirNomadsAgile.Data;
using AirNomadsAgile.Models.Movies;
using AirNomadsAgile.Models.Ratings;
using AirNomadsAgile.Models.Shows;

namespace AirNomadsAgile.Services
{
    public class RatingsServices
    {

        private readonly Guid _userId;

        public RatingsServices(Guid userId)
        {
            _userId = userId;
        }
        // CRUD methods go below

        // Read
        public IEnumerable<RatingsListItem> GetAllRatings()
        {
            using (var ctx = new Data.ApplicationDbContext())
            {
                var showList = ctx.Ratings.Select(m => new RatingsListItem()
                {
                    Id = m.Id,
                    StarRating = m.StarRating,
                }).ToList();
                return showList;
            }
        }

        public RatingsGetById GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.Id == id);
                return
                    new RatingsGetById()
                    {
                        Id = entity.Id,
                        StarRating = entity.StarRating
                    };
            };
        }




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirNomadsAgile.Data;
using AirNomadsAgile.Models.Movies;
using AirNomadsAgile.Models.Shows;

namespace AirNomadsAgile.Services
{
    public class ShowServices
    {
        private readonly Guid _userId;

        public ShowServices(Guid userId)
        {
            _userId = userId;
        }
        // CRUD methods go below

        // Read
        public IEnumerable<ShowsListItem> GetAllShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var showList = ctx.Shows.Select(s => new ShowsListItem
                {
                    Id = s.Id,
                    Title = s.Title,
                }).ToList();
                return showList;
            }
        }

        public ShowGetById GetShowGetByIdById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.Id == id);
                return
                    new ShowGetById()
                    {
                        Id = entity.Id,
                        Title = entity.Title
                    };
            };
        }





    }
}
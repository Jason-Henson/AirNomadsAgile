using AirNomadsAgile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AirNomadsAgile.Controllers
{
    public class RatingController : ApiController
    {
        private readonly MovieRaterDbContext _dbContext = new MovieRaterDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> AddRating()
        {
            Rating rating = new Rating();
            _dbContext.Ratings.Add(rating);
            if (await _dbContext.SaveChangesAsync() == 1) return Ok();
            return InternalServerError();
        }
    }
}

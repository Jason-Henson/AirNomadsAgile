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
    public class MovieController : ApiController
    {
        private readonly MovieRaterDbContext _dbContext = new MovieRaterDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> AddMovie(Item_Create model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Movie movie = new Movie()
            {
                Title = model.Title,
                Rating = model.Rating,
                Description = model.Description,
            };

            _dbContext.Movie.Add(movie);
            if (await _dbContext.SaveChangesAsync() == 1) return Ok();
            return InternalServerError();
        }
    }
}

using AirNomadsAgile.Data;
using AirNomadsAgile.Models.Movies;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AirNomadsAgile.Controllers
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> AddMovie(MovieCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Movie movie = new Movie();
            {
                movie.Id = model.Id;
                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.Rating = model.Rating;
            };

            _dbContext.Movies.Add(movie);
            if (await _dbContext.SaveChangesAsync() == 1) return Ok();
            return InternalServerError();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAllMovies()
        {
            return Ok(await _dbContext.Movies.ToListAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMovieById([FromUri] string id)
        {
            Movie movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null) return NotFound();

            return Ok(movie);
        }

        [HttpPut]
        [ActionName("Update")]
        public async Task<IHttpActionResult> UpdateMovie([FromUri] string id, [FromBody] MovieEdit model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Movie movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null) return NotFound();

            movie.Title = model.Title;
            movie.Description = model.Description;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMovie(int Id)
        {
            Movie movie = await _dbContext.Movies.FindAsync(Id);

            if (movie == null) return NotFound();

            _dbContext.Movies.Remove(movie);

            if (await _dbContext.SaveChangesAsync() == 1)
            {
                return Ok();
            }

            return InternalServerError();
        }

    }
}

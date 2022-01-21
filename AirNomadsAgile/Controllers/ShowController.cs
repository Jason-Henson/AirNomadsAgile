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
    public class ShowController : ApiController
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> AddMovie(ShowCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Show show = new Show();
            {
                show.Id = model.Id;
                show.Title = model.Title;
                show.Description = model.Description;
                show.Rating = model.Rating;
            };

            _dbContext.Shows.Add(show);
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
            Movie show = await _dbContext.Movies.FindAsync(id);

            if (show == null) return NotFound();

            return Ok(show);
        }

        [HttpPut]
        [ActionName("Update")]
        public async Task<IHttpActionResult> UpdateMovie([FromUri] string id, [FromBody] ShowEdit model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Movie show = await _dbContext.Movies.FindAsync(id);

            if (show == null) return NotFound();

            show.Title = show.Title;
            show.Description = model.Description;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMovie(int Id)
        {
            Movie show = await _dbContext.Movies.FindAsync(Id);

            if (show == null) return NotFound();

            _dbContext.Movies.Remove(show);

            if (await _dbContext.SaveChangesAsync() == 1)
            {
                return Ok();
            }

            return InternalServerError();
        }
    }
}

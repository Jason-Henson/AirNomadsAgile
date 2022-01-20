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
    public class ShowController : ApiController
    {
        private readonly MovieRaterDbContext _dbContext = new MovieRaterDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> AddShow(Item_Create model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Show show = new Show()
            {
                Title = model.Title,
                Rating = model.Rating,
                Description = model.Description,
            };

            _dbContext.Show.Add(show);
            if (await _dbContext.SaveChangesAsync() == 1) return Ok();
            return InternalServerError();
        }
    }
}

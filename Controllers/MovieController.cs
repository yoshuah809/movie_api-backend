using Microsoft.AspNetCore.Mvc;
using movies_api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Controllers
{
        [Route("api/[controller]")]
    public class MovieController : Controller
    {
      private readonly MoviesDbContext context;
      public MovieController(MoviesDbContext context)

        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Movie.Select(p => new {
                    p.MovieId,
                    p.Title,
                    p.Year,
                    p.Time,
                    p.Genre,
                    p.Director,
                    p.Actors,
                    p.Sinopsis,
                    p.Portrait,
                    p.Price

                }).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
             
            }
        }
    }
}

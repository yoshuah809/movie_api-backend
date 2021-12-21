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
                    p.Price,
                    p.Rating

                }).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
             
            }

        }


        [Route("[action]/{value}")]
        [HttpGet("SearchBy")]
        public ActionResult SearchBy(string value)
        {
            try
            {
                return Ok(context.Movie.Select(m =>
                new
                {
                    m.MovieId,
                    m.Title,
                    m.Year,
                    m.Time,
                    m.Genre,
                    m.Director,
                    m.Actors,
                    m.Sinopsis,
                    m.Portrait,
                    m.Price,
                    m.Rating

                }).Where(m => m.Genre.Contains(value) ||
                m.Title.Contains(value) ||
                m.Genre.Contains(value) ||
                m.Director.Contains(value) ||
                m.Actors.Contains(value)));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
                }

        }


        [Route("[action]/{rating}")]
        [HttpGet("GetTopRated")]
        public ActionResult GetTopRated(int rating)
        {
            try
            {
                return Ok(context.Movie.Select(m =>
                new
                {
                    m.MovieId,
                    m.Title,
                    m.Year,
                    m.Time,
                    m.Genre,
                    m.Director,
                    m.Actors,
                    m.Sinopsis,
                    m.Portrait,
                    m.Price,
                    m.Rating

                }).Where(m => m.Rating >= rating));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}

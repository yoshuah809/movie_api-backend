using Microsoft.AspNetCore.Mvc;
using movies_api.Context;
using movies_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Controllers
{
    [Route("api/[controller]")]
    public class FavoritesController : Controller
    {
        private readonly MoviesDbContext context;

        public FavoritesController(MoviesDbContext context )
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get ()
        {
            try
            {
                return Ok(context.Favorites.Select(m => m.Movie));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult Add([FromBody] Favorites favorites)
        {
            try
            {
                context.Favorites.Add(favorites);
                context.SaveChanges();
                return Ok(favorites);
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult Delete([FromBody] Favorites favorites)
        {
            try
            {
                context.Favorites.Remove(favorites);
                context.SaveChanges();
                return Ok(favorites);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

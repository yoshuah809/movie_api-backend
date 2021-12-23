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
    public class UserController : Controller
    {
        private readonly MoviesDbContext context;
        public UserController(MoviesDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult Post([FromBody] User tuser)
        {
            try
            {
                context.User.Add(tuser);
                context.SaveChanges();
                return Ok(tuser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private int TryParse(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}

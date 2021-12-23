using Microsoft.AspNetCore.Authorization;
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
    public class LoginController : Controller

    {
        private readonly MoviesDbContext context;
        
        public LoginController(MoviesDbContext context)

        {
            this.context = context;
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login([FromBody] User user)
        {

            string token = "";

            User validUser = context.User.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if(validUser != null)
            {
                token = "Token";
            }
            


            return Ok(token);
           
           

        }
    }
}

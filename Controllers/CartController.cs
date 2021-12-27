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
    public class CartController : Controller
    {
        private readonly MoviesDbContext context;
        public CartController(MoviesDbContext context)
        {
            this.context = context;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult Buy([FromBody] List<Cart> cart )
        {
            try
            {
                foreach (var item in cart)
                {
                    context.Cart.Add(item);
                    context.SaveChanges();
                }

                return Ok(cart);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

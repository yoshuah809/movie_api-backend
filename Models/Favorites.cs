using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Models
{
    public class Favorites
    {
        public int UserID { get; set; }
        public int MovieId { get; set; }
        public User User { get; set; }
        public Movie Movie {get; set; }
    }
}

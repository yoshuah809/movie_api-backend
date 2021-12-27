using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string  Actors { get; set; }
        public string Sinopsis { get; set; }
        public string Portrait { get; set; }
        public byte Rating { get; set; }
        public decimal Price { get; set; }

        public List<Favorites> Favorites { get; set; }

        public List<Cart> Cart { get; set; }
    }
}

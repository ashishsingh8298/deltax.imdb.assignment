using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int ProducerId { get; set; }
        public string PosterUrl { get; set; }
    }
}

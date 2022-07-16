using System;
using System.Collections.Generic;

namespace deltax.imdb.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActorsMapping = new HashSet<MovieActorsMapping>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int ProducerId { get; set; }
        public string PosterUrl { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual ICollection<MovieActorsMapping> MovieActorsMapping { get; set; }
    }
}

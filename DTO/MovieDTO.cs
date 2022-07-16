using deltax.imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.DTO
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public string PosterUrl { get; set; }
        public DateTime DateOfRelease { get; set; }
        public ProducerModel Producer { get; set; }
        public List<ActorModel> Actors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.Models
{
    public class MovieActorMappingModel
    {
        public int MovieActorsId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}

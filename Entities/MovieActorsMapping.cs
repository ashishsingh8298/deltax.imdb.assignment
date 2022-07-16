using System;
using System.Collections.Generic;

namespace deltax.imdb.Models
{
    public partial class MovieActorsMapping
    {
        public int MovieActorsId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

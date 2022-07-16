using System;
using System.Collections.Generic;

namespace deltax.imdb.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActorsMapping = new HashSet<MovieActorsMapping>();
        }

        public int ActorId { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<MovieActorsMapping> MovieActorsMapping { get; set; }
    }
}

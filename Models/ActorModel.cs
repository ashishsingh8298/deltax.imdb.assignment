using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.Models
{
    public class ActorModel
    {
        public int ActorId { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
    }
}

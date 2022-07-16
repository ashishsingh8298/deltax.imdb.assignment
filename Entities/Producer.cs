using System;
using System.Collections.Generic;

namespace deltax.imdb.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Movie = new HashSet<Movie>();
        }

        public int ProducerId { get; set; }
        public string ProducerFirstName { get; set; }
        public string ProducerLastName { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}

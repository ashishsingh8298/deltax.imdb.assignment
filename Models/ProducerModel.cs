using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.Models
{
    public class ProducerModel
    {
        public int ProducerId { get; set; }
        public string ProducerFirstName { get; set; }
        public string ProducerLastName { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }
    }
}

using deltax.imdb.DeltaXDBContext;
using deltax.imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.DataBaseLayer
{
    public class ProducerDB
    {
        private readonly ImdbContext _dbContext;

        public ProducerDB(ImdbContext imdbContext)
        {
            _dbContext = imdbContext;
        }

        public ProducerModel GetProducerByProducerId(int ProducerId)
        {
            try
            {
                var producer = _dbContext.Producer.Find(ProducerId);

                if (producer == null)
                {
                    return null;
                }

                return new ProducerModel()
                {
                    ProducerId = producer.ProducerId,
                    ProducerFirstName = producer.ProducerFirstName,
                    ProducerLastName = producer.ProducerLastName,
                    Bio = producer.Bio,
                    Dob = producer.Dob,
                    Company = producer.Company,
                    Gender = producer.Gender
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

using deltax.imdb.DeltaXDBContext;
using deltax.imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.DataBaseLayer
{
    public class ActorDB
    {
        private readonly ImdbContext _dbContext;

        public ActorDB(ImdbContext imdbContext)
        {
            _dbContext = imdbContext;
        }

        public List<Actor> GetActors()
        {
            try
            {
                return _dbContext.Actor.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<ActorModel> GetActorsForMovie(int MovieId)
        {
            try
            {
                var movie = _dbContext.Movie.Find(MovieId);

                if (movie == null)
                {
                    return null;
                }

                var actorList= _dbContext.MovieActorsMapping.Where(x=>x.MovieId==movie.MovieId);

                return _dbContext.Actor.Join(actorList, actor => actor.ActorId, actorList => actorList.ActorId, (x, y) => x)
                    .Select(x=>new ActorModel {
                        ActorId=x.ActorId,
                        ActorFirstName = x.ActorFirstName,
                        ActorLastName = x.ActorLastName,
                        Bio = x.Bio,
                        Dob = x.Dob,
                        Gender = x.Gender

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}

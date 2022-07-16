using deltax.imdb.DeltaXDBContext;
using deltax.imdb.DTO;
using deltax.imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.DataBaseLayer
{
    public class MovieDB
    {
        private readonly ImdbContext _dbContext;

        public MovieDB(ImdbContext imdbContext)
        {
            _dbContext = imdbContext;
        }

        public List<MovieModel> GetMovies() {
            try
            {
                return _dbContext.Movie.Select(x=>new MovieModel { 
                    MovieId=x.MovieId,
                    MovieName = x.MovieName,
                    Plot = x.Plot,
                    DateOfRelease = x.DateOfRelease,
                    ProducerId = x.ProducerId,
                    PosterUrl = x.PosterUrl
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int AddMovie(MovieDTO movieParamObj)
        {
            try
            {
                List<ActorModel> actorParamObj = movieParamObj.Actors;

                var insertMovie = new Movie
                {
                    MovieName = movieParamObj.MovieName,
                    Plot = movieParamObj.MovieName,
                    DateOfRelease = movieParamObj.DateOfRelease,
                    PosterUrl = movieParamObj.PosterUrl,
                    ProducerId = movieParamObj.Producer.ProducerId
                };


                var mov = _dbContext.Movie.Add(insertMovie);

                var listActorMapping = actorParamObj.Select(x => new MovieActorsMapping
                {
                    ActorId = x.ActorId,
                    MovieId = Convert.ToInt32(mov.CurrentValues["MovieId"])
                }).AsEnumerable();

                _dbContext.MovieActorsMapping.AddRange(listActorMapping);
                _dbContext.SaveChanges();


                return Convert.ToInt32(mov.CurrentValues["MovieId"]);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int EditMovie(MovieDTO movieParamObj)
        {
            try
            {
                List<ActorModel> actorParamObj = movieParamObj.Actors;

                var insertMovie = new Movie
                {
                    MovieId= movieParamObj.MovieId,
                    MovieName = movieParamObj.MovieName,
                    Plot = movieParamObj.MovieName,
                    DateOfRelease = movieParamObj.DateOfRelease,
                    PosterUrl = movieParamObj.PosterUrl,
                    ProducerId = movieParamObj.Producer.ProducerId
                };

                var mov = _dbContext.Movie.Update(insertMovie);

                var actors=_dbContext.MovieActorsMapping.Where(x=>x.MovieId== Convert.ToInt32(mov.CurrentValues["MovieId"])).Select(x => new MovieActorsMapping
                {
                    MovieActorsId = x.MovieActorsId,
                    ActorId = x.ActorId,
                    MovieId = Convert.ToInt32(mov.CurrentValues["MovieId"])
                }).AsEnumerable();

                _dbContext.MovieActorsMapping.RemoveRange(actors);
                var listActorMapping = actorParamObj.Select(x => new MovieActorsMapping
                {
                    ActorId = x.ActorId,
                    MovieId = Convert.ToInt32(mov.CurrentValues["MovieId"])
                }).AsEnumerable();

                _dbContext.MovieActorsMapping.UpdateRange(listActorMapping);
                _dbContext.SaveChanges();


                return Convert.ToInt32(mov.CurrentValues["MovieId"]);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}

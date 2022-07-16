using deltax.imdb.DataBaseLayer;
using deltax.imdb.DTO;
using deltax.imdb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deltax.imdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly MovieDB _movieDB;
        private readonly ActorDB _actorDB;
        private readonly ProducerDB _producerDB;

        public MovieController(ILogger<MovieController> logger, MovieDB movieDB, ActorDB actorDB, ProducerDB producerDB)
        {
            _logger = logger;
            _movieDB = movieDB;
            _actorDB = actorDB;
            _producerDB = producerDB;
        }

        #region Get All Movies
        /// <summary>
        /// Get All the Movies with their actors and producers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<MovieDTO>> Get()
        {
            try
            {
                return _movieDB.GetMovies().Select(movie => new MovieDTO
                {
                    MovieId = movie.MovieId,
                    MovieName = movie.MovieName,
                    Plot = movie.Plot,
                    DateOfRelease = movie.DateOfRelease,
                    Producer = _producerDB.GetProducerByProducerId(movie.ProducerId),
                    Actors = _actorDB.GetActorsForMovie(movie.MovieId).ToList(),
                    PosterUrl = movie.PosterUrl
                }).ToList();
            }
            catch
            {
                return NoContent();
            }

        }
        #endregion

        #region Get Movie with id
        /// <summary>
        /// Get the specific Movie with their actors and producers
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<MovieModel> Get(int id)
        {
            try
            {
                var movie = _movieDB.GetMovie(id);

                if (movie == null)
                {
                    return NotFound();
                }

                return movie;
            }
            catch
            {
                return NoContent();
            }

        }
        #endregion

        #region Create Movies
        /// <summary>
        /// Create movies with their actors and producers
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> Post([FromBody] MovieDTO movieModel)
        {
            try
            {
                return _movieDB.AddMovie(movieModel);
            }
            catch
            {
                return NoContent();
            }

        }
        #endregion

        #region Edit Movies
        /// <summary>
        /// Edit movies with their actors and producers
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<int> Put([FromBody] MovieDTO movieModel)
        {
            try
            {
                return _movieDB.EditMovie(movieModel);
            }
            catch
            {
                return NoContent();
            }

        }
        #endregion
    }
}

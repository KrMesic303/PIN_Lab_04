using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Services;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        #region Get Movies

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = MoviesService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MoviesService.GetMovieById(id);
            return Ok(movie);
        }

        #endregion

        #region Add, update, delete

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie([FromQuery] int id, [FromBody] Movie movie)
        {
            var updatedMovie = MoviesService.UpdateMovieById(id, movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }


        #endregion



    }
}

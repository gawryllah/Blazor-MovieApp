using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Server.Services;
using MovieApp.Shared.Models;
using System.Threading.Tasks;


namespace MovieApp.Server.Controllers
{
    [Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesDbService _dbService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _dbService.GetMovies());
        }

        [HttpPost]
        public async Task<IActionResult> AddMovies([FromBody] Movie movie)
        {

            if (movie != null)
            {


                return Ok(await _dbService.AddMovie(movie));
            }
            else
            {
                return StatusCode(420, "Error with adding movie to DB!");
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {

            return Ok(await _dbService.DeleteMovie(id));

        }


        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] Movie movie)
        {

            return Ok(await _dbService.EditMovie(movie));

        }
    }
}

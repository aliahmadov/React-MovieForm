using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieForm.DataAcces.DbContexts;
using MovieForm.DataAcces.Entities;
using MovieForm.Dtos;

namespace MovieForm.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private MovieDbContext _context { get; set; }

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDto movieDto)
        {
            try
            {
                var itemToBeAdded = new Movie
                {
                    Id = movieDto.Id,
                    MovieName = movieDto.MovieName,
                    PosterUrl = movieDto.PosterUrl,
                    ProductionYear = movieDto.ProductionYear,
                    TrailerUrl = movieDto.TrailerUrl
                };
                _context.Add(itemToBeAdded);
                _context.SaveChanges();


                return Ok(_context.Movies);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var itemToBeDeleted = _context.Movies.FirstOrDefault(c => c.Id == id);
                _context.Movies.Remove(itemToBeDeleted);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        public IActionResult Update(int id, [FromBody] MovieDto movieDto)
        {
            try
            {
                var itemToBeUpdated = _context.Movies.FirstOrDefault(c => c.Id == id);

                itemToBeUpdated.PosterUrl = movieDto.PosterUrl;
                itemToBeUpdated.TrailerUrl = movieDto.TrailerUrl;
                itemToBeUpdated.ProductionYear = movieDto.ProductionYear;
                itemToBeUpdated.MovieName = movieDto.MovieName;
                _context.Movies.Update(itemToBeUpdated);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }


}

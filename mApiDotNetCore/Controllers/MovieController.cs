using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.interfaces;
using System.Collections.Generic;

namespace mApiDotNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : GenericController<Movie> 
    {
        private readonly IMovieService _service;
        public MovieController(IServiceGeneric<Movie> srv, IMovieService service) : base(srv)
        {
            this._service = service;
        }

        [HttpGet("{title}")]
        public IEnumerable<Movie> Get(string title = null)
        {
            return _service.GetAllMovies(title);
        }


        [HttpPut("{id}")]
        public Movie Update(int id, Movie movie)
        {
            movie.Id = id;
            return _service.Update(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_service.Delete(id))
            {
                return Ok();
            }
            return BadRequest("Cannot delete movie in db");
        }

    }
}
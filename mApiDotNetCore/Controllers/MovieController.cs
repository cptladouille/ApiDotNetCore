using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Interfaces;
using Service.interfaces;

namespace mApiDotNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService mRepo;

        public MovieController(IMovieService mRepo)
        {
            this.mRepo = mRepo;
        }

        [HttpGet("{title}")]
        public IEnumerable<Movie> Get(string title = null)
        {
            return mRepo.GetAllMovies(title);
        }

        [HttpGet]
        public IEnumerable<Movie> GetByTitle()
        {
            return mRepo.GetAllMovies();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var res = mRepo.Add(movie);
            if(res != null)
            {
                return Ok(res);
            }
            return BadRequest("Cannot add movie in db, check payload");
        }

        [HttpPut("{id}")]
        public Movie Update(int id, Movie movie)
        {
            return mRepo.Update(id, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(mRepo.Delete(id))
            {
                return Ok();
            }
            return BadRequest("Cannot delete movie in db");
        }
    }
}
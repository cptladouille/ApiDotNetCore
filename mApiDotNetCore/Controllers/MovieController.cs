using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IEnumerable<Movie> Get()
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
        public bool Delete(int id)
        {
            return mRepo.Delete(id);
        }

    }
}
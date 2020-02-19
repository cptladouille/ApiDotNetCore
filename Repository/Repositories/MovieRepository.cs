using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            this._context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return this._context.Movies.ToList();
        }

        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public bool Delete(int id)
        {
            _context.Movies.Remove(GetAllMovies().Find(x => x.Id == id));
            _context.SaveChanges();
            return true;
        }

        public Movie Update(int id, Movie movie)
         {

             Movie toModify = GetAllMovies().Find(x => x.Id == id);
             movie.Id = id;
             _context.Entry(toModify).CurrentValues.SetValues(movie);
             _context.SaveChanges();
             return toModify;
         }

        public Movie GetByTitle(string movieTitle)
        {
            return _context.Movies.FirstOrDefault(x => x.Title == movieTitle);
        }
    }
}

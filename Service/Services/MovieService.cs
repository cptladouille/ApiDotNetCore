using System;
using System.Collections.Generic;
using System.Text;
using Service.interfaces;
using Model.Entities;
using Repository.Interfaces;

namespace Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _mRepo;
        public MovieService(IMovieRepository repo)
        {
            this._mRepo = repo;
        }
        public Movie Add(Movie movie)
        {
            var dbMovie = _mRepo.GetByTitle(movie.Title);
            if (dbMovie == null)
            {
                return this._mRepo.Add(movie);
            }

            return null;
        }

        public List<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Movie Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}

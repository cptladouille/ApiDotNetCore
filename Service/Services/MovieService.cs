using System;
using System.Collections.Generic;
using System.Linq;
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
            if (dbMovie == null && CheckDateMin(movie))
            {
                return this._mRepo.Add(movie);
            }
            return null;
        }

        public List<Movie> GetAllMovies(string title =null)
        {
            return _mRepo.GetAllMovies(title);
        }

        public Movie Update(int id, Movie movie)
        {
            if (_mRepo.GetByTitle(movie.Title) != null || CheckDateMin(movie))
            {
                return null;
            }
            return _mRepo.Update(id, movie);
        }

        public bool Delete(int id)
        {
            return _mRepo.Delete(id);
        }

        public bool CheckDateMin(Movie movie)
        {
            return movie.ReleaseDate.Year > 1981;
        }
    }
}
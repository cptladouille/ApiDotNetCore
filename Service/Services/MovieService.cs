using Model.Entities;
using Repository.Interfaces;
using Service.interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class MovieService : ServiceGeneric<Movie>, IMovieService
    {
        private readonly IMovieRepository _mRepo;
        public MovieService(IMovieRepository repo, IRepositoryGeneric<Movie> movieRepo) : 
            base(movieRepo)
        {
            this._mRepo = repo;
        }

        public override Movie Create(Movie movie)
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
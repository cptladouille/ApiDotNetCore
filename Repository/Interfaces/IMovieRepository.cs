using System;
using System.Collections.Generic;
using System.Text;
using Model.Entities;

namespace Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie Add(Movie movie);
        bool Delete(int id);
        Movie Update(int id, Movie movie);
        Movie GetByTitle(string movieTitle);
    }
}

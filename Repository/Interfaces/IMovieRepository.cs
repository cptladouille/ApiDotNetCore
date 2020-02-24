using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Model.Entities;

namespace Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies(string title);
        Movie Add(Movie movie);
        bool Delete(int id);
        Movie Update(int id, Movie movie);
        Movie GetByTitle(string movieTitle);
    }
}

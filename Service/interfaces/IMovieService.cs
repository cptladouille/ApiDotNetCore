using System;
using System.Collections.Generic;
using System.Text;
using Model.Entities;

namespace Service.interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie Add(Movie movie);
        bool Delete(int id);
        Movie Update(int id, Movie movie);
    }
}

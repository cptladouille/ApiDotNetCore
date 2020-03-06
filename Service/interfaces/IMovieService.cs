using Model.Entities;
using System.Collections.Generic;

namespace Service.interfaces
{
    public interface IMovieService : IServiceGeneric<Movie>
    {
        List<Movie> GetAllMovies(string title = null);
    }
}

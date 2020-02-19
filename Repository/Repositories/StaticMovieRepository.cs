using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Model.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class StaticMovieRepository 
    {
        public List<Movie> GetAllMovies()
        {
            return new List<Movie>()
            {
                new Movie()
                {
                        Title = "La corde du diable",
                        Description ="L'histoire du barbelé ",
                        Duration = 152,
                        ReleaseDate = DateTime.Now
                }
            };
        }

        public Movie Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Movie Update(Guid id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Movie> DirectedMovies { get; set; }
        public ICollection<MovieActor> PlayedMovies { get; set; }
        

    }
}

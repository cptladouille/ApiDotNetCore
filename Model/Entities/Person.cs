using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace Model.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }
        [JsonIgnore]
        public ICollection<Movie> DirectedMovies { get; set; }
        [JsonIgnore]
        public ICollection<MovieActor> PlayedMovies { get; set; }
        

    }
}

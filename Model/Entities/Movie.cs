using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Movie
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate  { get; set; }
        public Person Director { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<MovieActor> Actors { get; set; }


        public Movie()
        {
        }

        public Movie(string title, string description, int duration, DateTime releaseDate)
        {
            Title = title;
            Description = description;
            Duration = duration;
            ReleaseDate = releaseDate;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

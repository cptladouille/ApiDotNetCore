using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class MovieActor
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public Movie Movie { get; set; }
        public Person Actor { get; set; }
    }
}

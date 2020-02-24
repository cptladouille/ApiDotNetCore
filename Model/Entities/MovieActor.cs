using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class MovieActor
    {
        public int IdMovie { get; set; }
        public int IdPerson { get; set; }
        public Movie Movie { get; set; }
        public Person Actor { get; set; }
    }
}

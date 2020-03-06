using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.Interfaces;
using Newtonsoft.Json;

namespace Model.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [JsonIgnore]
        public List<Movie> Movies { get; set; }
    }
}

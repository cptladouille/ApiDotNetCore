using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model
{
    public class MovieDbContext: DbContext

    {
        public virtual DbSet<Movie> Movies { get; set; }

        public MovieDbContext()
        {

        }

        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=moviedb;uid=root;password=");
            }
        }
    }
}
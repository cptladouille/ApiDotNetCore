using System.Security.Cryptography.X509Certificates;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.DirectedMovies)
                .WithOne(x => x.Director);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Actors)
                .WithOne(x => x.Movie);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.PlayedMovies)
                .WithOne(x => x.Actor);

            modelBuilder.Entity<MovieActor>().HasKey(x => new {x.IdPerson, x.IdMovie});

            /*
             *dotnet ef migrations add migration_2 --project Model --startup-project mApiDotNetCore
             *
             * dotnet ef database update --project Model --startup-project mApiDotNetCore
             *
             */
        }
    }
}
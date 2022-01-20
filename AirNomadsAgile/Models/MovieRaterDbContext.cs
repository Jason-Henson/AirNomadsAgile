using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirNomadsAgile.Models
{
    public class MovieRaterDbContext : DbContext
    {
        public MovieRaterDbContext() : base("DefaultConnection") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}
using Microsoft.EntityFrameworkCore;
using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.DataAccess.Concrete.EfCore
{
    public class MovieContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieDb;integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasKey(c => new { c.CategoryId, c.MovieId });
        }
        public DbSet<Entity.Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

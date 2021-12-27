using Microsoft.EntityFrameworkCore;
using movies_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Context
{
    public class MoviesDbContext:DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }
        public DbSet<Movie>Movie { get; set; }
        public DbSet<User>User { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Favorites> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorites>().HasKey(x => new { x.UserID, x.MovieId });

            modelBuilder.Entity<Favorites>().HasOne(x => x.User)
                .WithMany(f => f.Favorites)
                .HasForeignKey(u => u.UserID);

            modelBuilder.Entity<Favorites>().HasOne(x => x.Movie)
               .WithMany(f => f.Favorites)
               .HasForeignKey(u => u.MovieId);

            modelBuilder.Entity<Cart>().HasKey(x => new { x.UserID, x.MovieId });

            modelBuilder.Entity<Cart>().HasOne(x => x.User)
              .WithMany(f => f.Cart)
              .HasForeignKey(u => u.UserID);

            modelBuilder.Entity<Cart>().HasOne(x => x.Movie)
               .WithMany(f => f.Cart)
               .HasForeignKey(u => u.MovieId);
        }
    }
}

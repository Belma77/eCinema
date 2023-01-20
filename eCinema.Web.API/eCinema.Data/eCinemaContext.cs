using eCInema.Data.Entities;
using eCInema.Models;
using eCInema.Models.Entities;
using MediaBrowser.Model.Globalization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace eCinema.Data
{
    public class eCinemaContext : DbContext
    {
        public eCinemaContext(DbContextOptions<eCinemaContext> options) : base(options)
        {

        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<ActorsMovies> ActorsMovies {get;set;}
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorsMovies> DirectorsMovies {get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<WritersMovies> WritersMovies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerMovies> ProducersMovies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });
            builder.Entity<ActorsMovies>().HasKey(x => new { x.MovieId, x.ActorId });
            builder.Entity<DirectorsMovies>().HasKey(x => new { x.MovieId, x.DirectorId });
            builder.Entity<WritersMovies>().HasKey(x => new { x.MovieId, x.WriterId });
            builder.Entity<ProducerMovies>().HasKey(x => new { x.MovieId, x.ProducerId });

        }
    }
}

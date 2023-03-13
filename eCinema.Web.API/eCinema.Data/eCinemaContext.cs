using eCInema.Data.Entities;
using eCInema.Models;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using MediaBrowser.Model.Globalization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
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
        public DbSet<ActorsMovies> ActorsMovies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorsMovies> DirectorsMovies { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<WritersMovies> WritersMovies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerMovies> ProducersMovies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<LoyalCard> LoyalCards { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ScheduleSeat> ScheduleSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });
            builder.Entity<ActorsMovies>().HasKey(x => new { x.MovieId, x.ActorId });
            builder.Entity<DirectorsMovies>().HasKey(x => new { x.MovieId, x.DirectorId });
            builder.Entity<WritersMovies>().HasKey(x => new { x.MovieId, x.WriterId });
            builder.Entity<ProducerMovies>().HasKey(x => new { x.MovieId, x.ProducerId });

            builder.Entity<Schedule>().HasOne(x => x.Hall).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ScheduleSeat>().HasOne(x => x.Seat).WithMany().OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Seat>()
                        .HasOne(s => s.Hall)
                        .WithMany(g => g.Seats).HasForeignKey(s => s.HallId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Hall>().HasMany(x => x.Seats).WithOne(x => x.Hall).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>().HasDiscriminator<UserRole>("Discriminator")
                .HasValue<Customer>(UserRole.Customer)
                .HasValue<User>(UserRole.Admin);

            builder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        }
        
        
    }
}


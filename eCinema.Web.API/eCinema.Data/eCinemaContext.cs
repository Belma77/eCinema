using eCinema.Data.DataSeeder;
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

            ////SeedData(builder);
            ////SeedActorsData.SeedActors(builder);
            ////SeedMoviesActorsData.SeedMoviesActors(builder);
            ////SeedDirectorsData.SeedDirectors(builder);
            ////SeedDirectorsMoviesData.SeedMoviesDirectors(builder);
            ////SeedProducersData.SeedProducers(builder);
            ////SeedMoviesProducersData.SeedMoviesProducers(builder);
            ////SeedWritersData.SeedWriters(builder);
            ////SeedWriterMovies.SeedWritersMovies(builder);
            ////SeedGenresData.SeedGenres(builder);
            ////SeedMoviesGenresData.SeedMoviesGenres(builder);
            ////SeedHallsData.SeedHalls(builder);
            ////SeedSchedules(builder);
            ////SeedMoviesData.SeedMovies(builder);
            ////SeedUsersData.SeedUsers(builder);
        }
            

    private void SeedSchedules(ModelBuilder builder)
        {
            builder.Entity<Schedule>().HasData(
                new Schedule() { Id = 1, Date = DateTime.Now, StartTime = DateTime.Now, HallId = 1, MovieId = 1, NoAvailableSeats = 50, TicketPrice = 7.50 }
                );
        }

      
        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Seat>().HasData(

                new Seat() { Id = 1, Row = "A", Column = 1, HallId = 1 },
                new Seat() { Id = 2, Row = "A", Column = 2, HallId = 1 },
                new Seat() { Id = 3, Row = "A", Column = 3, HallId = 1 },
                new Seat() { Id = 4, Row = "A", Column = 4, HallId = 1 },
                new Seat() { Id = 5, Row = "A", Column = 5, HallId = 1 },
                new Seat() { Id = 6, Row = "A", Column = 6, HallId = 1 },
                new Seat() { Id = 7, Row = "A", Column = 7, HallId = 1 },
                new Seat() { Id = 8, Row = "A", Column = 8, HallId = 1 },
                new Seat() { Id = 9, Row = "A", Column = 9, HallId = 1 },
                new Seat() { Id = 10, Row = "A", Column = 10, HallId = 1 },

                new Seat() { Id = 11, Row = "B", Column = 1, HallId = 1 },
                new Seat() { Id = 12, Row = "B", Column = 2, HallId = 1 },
                new Seat() { Id = 13, Row = "B", Column = 3, HallId = 1 },
                new Seat() { Id = 14, Row = "B", Column = 4, HallId = 1 },
                new Seat() { Id = 15, Row = "B", Column = 5, HallId = 1 },
                new Seat() { Id = 16, Row = "B", Column = 6, HallId = 1 },
                new Seat() { Id = 17, Row = "B", Column = 7, HallId = 1 },
                new Seat() { Id = 18, Row = "B", Column = 8, HallId = 1 },
                new Seat() { Id = 19, Row = "B", Column = 9, HallId = 1 },
                new Seat() { Id = 20, Row = "B", Column = 10, HallId = 1 },

                new Seat() { Id = 21, Row = "C", Column = 1, HallId = 1 },
                new Seat() { Id = 22, Row = "C", Column = 2, HallId = 1 },
                new Seat() { Id = 23, Row = "C", Column = 3, HallId = 1 },
                new Seat() { Id = 24, Row = "C", Column = 4, HallId = 1 },
                new Seat() { Id = 25, Row = "C", Column = 5, HallId = 1 },
                new Seat() { Id = 26, Row = "C", Column = 6, HallId = 1 },
                new Seat() { Id = 27, Row = "C", Column = 7, HallId = 1 },
                new Seat() { Id = 28, Row = "C", Column = 8, HallId = 1 },
                new Seat() { Id = 29, Row = "C", Column = 9, HallId = 1 },
                new Seat() { Id = 30, Row = "C", Column = 10, HallId = 1 },

                 new Seat() { Id = 31, Row = "D", Column = 1, HallId = 1 },
                 new Seat() { Id = 32, Row = "D", Column = 2, HallId = 1 },
                 new Seat() { Id = 33, Row = "D", Column = 3, HallId = 1 },
                 new Seat() { Id = 34, Row = "D", Column = 4, HallId = 1 },
                 new Seat() { Id = 35, Row = "D", Column = 5, HallId = 1 },
                 new Seat() { Id = 36, Row = "D", Column = 6, HallId = 1 },
                 new Seat() { Id = 37, Row = "D", Column = 7, HallId = 1 },
                 new Seat() { Id = 38, Row = "D", Column = 8, HallId = 1 },
                 new Seat() { Id = 39, Row = "D", Column = 9, HallId = 1 },
                 new Seat() { Id = 40, Row = "D", Column = 10, HallId = 1 },

                 new Seat() { Id = 41, Row = "E", Column = 1, HallId = 1 },
                 new Seat() { Id = 42, Row = "E", Column = 2, HallId = 1 },
                 new Seat() { Id = 43, Row = "E", Column = 3, HallId = 1 },
                 new Seat() { Id = 44, Row = "E", Column = 4, HallId = 1 },
                 new Seat() { Id = 45, Row = "E", Column = 5, HallId = 1 },
                 new Seat() { Id = 46, Row = "E", Column = 6, HallId = 1 },
                 new Seat() { Id = 47, Row = "E", Column = 7, HallId = 1 },
                 new Seat() { Id = 48, Row = "E", Column = 8, HallId = 1 },
                 new Seat() { Id = 49, Row = "E", Column = 9, HallId = 1 },
                 new Seat() { Id = 50, Row = "E", Column = 10, HallId = 1 });

        }

    }
}


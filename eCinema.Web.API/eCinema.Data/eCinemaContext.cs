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

            SeedData(builder);
            SeedActors(builder);
            SeedMoviesActors(builder);
            SeedDirectors(builder);
            SeedMoviesDirectors(builder);
            SeedProducers(builder);
            SeedMoviesProducers(builder);
            SeedWriters(builder);
            SeedWritersMovies(builder);
            SeedGenres(builder);
            SeedMoviesGenres(builder);

            SeedHalls(builder);
            SeedSchedules(builder);
            SeedMovies(builder);

            SeedUsers(builder);
        }
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var password = "pass123";
            var salt = GenerateSalt();
            var passwordSalt = salt;
            var passwordHash = GenerateHash(salt, password);
            builder.Entity<User>().HasData(
             new User() { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "admin@gmail.com", UserRole = UserRole.Admin, UserName = "Admin", PasswordSalt = salt, PasswordHash = passwordHash, Phone = "041233234" }

            );
            builder.Entity<Customer>().HasData(
               new Customer() { Id = 2, FirstName = "Customer", LastName = "Customer", Email = "customer@gmail.com", UserRole = UserRole.Customer, UserName = "Customer", PasswordSalt = salt, PasswordHash = passwordHash, Phone = "041233234" }
                );
        }

        private void SeedWritersMovies(ModelBuilder builder)
        {
            builder.Entity<WritersMovies>().HasData(
                new WritersMovies() { MovieId = 1, WriterId = 1 }
                );
        }

        private void SeedMoviesProducers(ModelBuilder builder)
        {
            builder.Entity<ProducerMovies>().HasData(
                new ProducerMovies() { MovieId = 1, ProducerId = 1 }
                );

        }

        private void SeedMoviesDirectors(ModelBuilder builder)
        {
            builder.Entity<DirectorsMovies>().HasData(
                new DirectorsMovies() { MovieId = 1, DirectorId = 1 }
                );
        }

        private void SeedMoviesActors(ModelBuilder builder)
        {
            builder.Entity<ActorsMovies>().HasData(
             new ActorsMovies() { MovieId = 1, ActorId = 1 }
             );
        }

        private void SeedMoviesGenres(ModelBuilder builder)
        {
            builder.Entity<MoviesGenres>().HasData(
                new MoviesGenres() { MovieId=1, GenreId=1}

            );
        }

        private void SeedGenres(ModelBuilder builder)
        {
            builder.Entity<Genres>().HasData(
                new Genres() { Id = 1, Genre = GenresEnum.Action },
                new Genres() { Id = 2, Genre = GenresEnum.Comedy },
                new Genres() { Id = 3, Genre = GenresEnum.Crime }
                );
        }

        private void SeedWriters(ModelBuilder builder)
        {
            builder.Entity<Writer>().HasData(
                new Writer() { Id = 1, FirstName = "Steve", LastName = "Kloves" });
        }

        private void SeedProducers(ModelBuilder builder)
        {
            builder.Entity<Producer>().HasData(
               new Producer() { Id = 1, FirstName = "Duncan", LastName = "Henderson" });
        }

        private void SeedDirectors(ModelBuilder builder)
        {
            builder.Entity<Director>().HasData(
             new Director() { Id = 1, FirstName = "Chris", LastName = "Columbus" });
        }

        private void SeedActors(ModelBuilder builder)
        {
            builder.Entity<Actor>().HasData(
           new Actor() { Id = 1, FirstName = "Daniel", LastName = "Radcliffe" });
        }

        private void SeedMovies(ModelBuilder builder)
        {

            builder.Entity<Movies>().HasData(
            new Movies()
            {
                Id = 1,
                Title = "Harry Potter and the Philosopher's Stone",
                ReleaseYear = 2001,
                Duration = 120,
                Country = "USA",
                Synopsis = "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
                
            }
           );
        }

        private void SeedSchedules(ModelBuilder builder)
        {
            builder.Entity<Schedule>().HasData(
                new Schedule() { Id = 1, Date = DateTime.Now, StartTime = DateTime.Now, HallId = 1, MovieId = 1, NoAvailableSeats = 50, TicketPrice = 7.50 }
                );
        }

        private void SeedHalls(ModelBuilder builder)
        {
            for (int i = 1; i <= 6; i++)
            {
                builder.Entity<Hall>().HasData(
                    new Hall() { Id = i, NoOfHall = i, NumberOfColumns = 10, NumberOfRows = 5, NumberOfSeats = 50 }
                    );
            }
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


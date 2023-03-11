using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Actor",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Actor", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Directors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Directors", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Genres",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Genre = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Genres", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Halls",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NoOfHall = table.Column<int>(type: "int", nullable: false),
            //        NumberOfSeats = table.Column<int>(type: "int", nullable: false),
            //        NumberOfRows = table.Column<int>(type: "int", nullable: false),
            //        NumberOfColumns = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Halls", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Movies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReleaseYear = table.Column<int>(type: "int", nullable: false),
            //        Duration = table.Column<int>(type: "int", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Movies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Producers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Producers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserRole = table.Column<int>(type: "int", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
            //        Discriminator = table.Column<int>(type: "int", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CustomerType = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Writers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Writers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Seats",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Column = table.Column<int>(type: "int", nullable: false),
            //        Row = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        HallId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Seats", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Seats_Halls_HallId",
            //            column: x => x.HallId,
            //            principalTable: "Halls",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ActorsMovies",
            //    columns: table => new
            //    {
            //        ActorId = table.Column<int>(type: "int", nullable: false),
            //        MovieId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ActorsMovies", x => new { x.MovieId, x.ActorId });
            //        table.ForeignKey(
            //            name: "FK_ActorsMovies_Actor_ActorId",
            //            column: x => x.ActorId,
            //            principalTable: "Actor",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ActorsMovies_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DirectorsMovies",
            //    columns: table => new
            //    {
            //        MovieId = table.Column<int>(type: "int", nullable: false),
            //        DirectorId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DirectorsMovies", x => new { x.MovieId, x.DirectorId });
            //        table.ForeignKey(
            //            name: "FK_DirectorsMovies_Directors_DirectorId",
            //            column: x => x.DirectorId,
            //            principalTable: "Directors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DirectorsMovies_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MoviesGenres",
            //    columns: table => new
            //    {
            //        MovieId = table.Column<int>(type: "int", nullable: false),
            //        GenreId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MoviesGenres", x => new { x.MovieId, x.GenreId });
            //        table.ForeignKey(
            //            name: "FK_MoviesGenres_Genres_GenreId",
            //            column: x => x.GenreId,
            //            principalTable: "Genres",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_MoviesGenres_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Schedules",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MovieId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        HallId = table.Column<int>(type: "int", nullable: false),
            //        TicketPrice = table.Column<double>(type: "float", nullable: false),
            //        NoAvailableSeats = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Schedules", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Schedules_Halls_HallId",
            //            column: x => x.HallId,
            //            principalTable: "Halls",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Schedules_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProducersMovies",
            //    columns: table => new
            //    {
            //        ProducerId = table.Column<int>(type: "int", nullable: false),
            //        MovieId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProducersMovies", x => new { x.MovieId, x.ProducerId });
            //        table.ForeignKey(
            //            name: "FK_ProducersMovies_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProducersMovies_Producers_ProducerId",
            //            column: x => x.ProducerId,
            //            principalTable: "Producers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LoyalCards",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        price = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LoyalCards", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LoyalCards_Users_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "WritersMovies",
            //    columns: table => new
            //    {
            //        WriterId = table.Column<int>(type: "int", nullable: false),
            //        MovieId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WritersMovies", x => new { x.MovieId, x.WriterId });
            //        table.ForeignKey(
            //            name: "FK_WritersMovies_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_WritersMovies_Writers_WriterId",
            //            column: x => x.WriterId,
            //            principalTable: "Writers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reservations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        ScheduleId = table.Column<int>(type: "int", nullable: false),
            //        NumberOfTickets = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: false),
            //        Status = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reservations", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Reservations_Schedules_ScheduleId",
            //            column: x => x.ScheduleId,
            //            principalTable: "Schedules",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Reservations_Users_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ScheduleSeats",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ScheduleId = table.Column<int>(type: "int", nullable: false),
            //        SeatId = table.Column<int>(type: "int", nullable: false),
            //        isTaken = table.Column<bool>(type: "bit", nullable: false),
            //        ReservationId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScheduleSeats", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ScheduleSeats_Reservations_ReservationId",
            //            column: x => x.ReservationId,
            //            principalTable: "Reservations",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ScheduleSeats_Schedules_ScheduleId",
            //            column: x => x.ScheduleId,
            //            principalTable: "Schedules",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ScheduleSeats_Seats_SeatId",
            //            column: x => x.SeatId,
            //            principalTable: "Seats",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProfilePicture", "UserName", "UserRole" },
            //    values: new object[] { 1, 0, "admin@gmail.com", "Admin", "Admin", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Admin", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CustomerType", "Discriminator", "Email", "FirstName", "IdentificationNumber", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProfilePicture", "UserName", "UserRole" },
                values: new object[,]
                {
                   // { 2, null, 0, 1, "customer@gmail.com", "Customer", null, "Customer", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer", 1 },
                    { 3, null, 0, 1, "customer2@gmail.com", "Custtomer2", null, "Customer2", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer2", 1 },
                    { 4, null, 0, 1, "customer3@gmail.com", "Custtomer3", null, "Customer3", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer3", 1 },
                    { 5, null, 0, 1, "customer4@gmail.com", "Custtomer4", null, "Customer4", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer4", 1 },
                    { 6, null, 0, 1, "customer5@gmail.com", "Custtomer5", null, "Customer5", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer5", 1 },
                    { 7, null, 0, 1, "customer6@gmail.com", "Custtomer6", null, "Customer6", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer6", 1 },
                    { 8, null, 0, 1, "customer7@gmail.com", "Custtomer7", null, "Customer7", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer7", 1 },
                    { 9, null, 0, 1, "customer8@gmail.com", "Custtomer8", null, "Customer8", "hZpCKKJe/ldF5aknmPVv+Um1nmo=", "0AdqnzK/z8aCabYQBTtSdA==", "041233234", null, "Customer8", 1 }
                });
        }

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ActorsMovies_ActorId",
        //        table: "ActorsMovies",
        //        column: "ActorId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DirectorsMovies_DirectorId",
        //        table: "DirectorsMovies",
        //        column: "DirectorId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LoyalCards_CustomerId",
        //        table: "LoyalCards",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_MoviesGenres_GenreId",
        //        table: "MoviesGenres",
        //        column: "GenreId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProducersMovies_ProducerId",
        //        table: "ProducersMovies",
        //        column: "ProducerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Reservations_CustomerId",
        //        table: "Reservations",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Reservations_ScheduleId",
        //        table: "Reservations",
        //        column: "ScheduleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Schedules_HallId",
        //        table: "Schedules",
        //        column: "HallId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Schedules_MovieId",
        //        table: "Schedules",
        //        column: "MovieId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ScheduleSeats_ReservationId",
        //        table: "ScheduleSeats",
        //        column: "ReservationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ScheduleSeats_ScheduleId",
        //        table: "ScheduleSeats",
        //        column: "ScheduleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ScheduleSeats_SeatId",
        //        table: "ScheduleSeats",
        //        column: "SeatId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Seats_HallId",
        //        table: "Seats",
        //        column: "HallId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_UserName",
        //        table: "Users",
        //        column: "UserName",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WritersMovies_WriterId",
        //        table: "WritersMovies",
        //        column: "WriterId");
        //}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsMovies");

            migrationBuilder.DropTable(
                name: "DirectorsMovies");

            migrationBuilder.DropTable(
                name: "LoyalCards");

            migrationBuilder.DropTable(
                name: "MoviesGenres");

            migrationBuilder.DropTable(
                name: "ProducersMovies");

            migrationBuilder.DropTable(
                name: "ScheduleSeats");

            migrationBuilder.DropTable(
                name: "WritersMovies");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

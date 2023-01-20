using eCinema.Data;
using eCinema.Services;
using eCinema.Services.ActorService;
using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCinema.Services.DirectorService;
using eCinema.Services.GenresServices;
using eCinema.Services.HallServices;
using eCinema.Services.MoviesServices;
using eCinema.Services.ProducerServices;
using eCinema.Services.Profiles;
using eCinema.Services.ScheduleServices;
using eCinema.Services.WritersServices;
using eCInema.Data.Dtos;
using eCInema.Models;
using eCInema.Models.Dtos;
using eCInema.Models.SearchObjects;
using MediaBrowser.Model.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

public class Program
{
    public static IConfiguration Configuration { get; set; }

    public Program(IConfiguration configuration)
    {
        Configuration = configuration;  
    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<eCinemaContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddAutoMapper(typeof(CustomProfile));

        builder.Services.AddTransient<IMoviesService, MoviesService>();
        builder.Services.AddTransient <IBaseService<MovieDetailsDto, MoviesSearchObject>, BaseService<MovieDetailsDto, Movies, MoviesSearchObject>>();
        builder.Services.AddTransient<IBaseCRUDService<MovieDetailsDto, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>, BaseCRUDService<MovieDetailsDto, Movies, MoviesSearchObject, MovieInsertDto,  MovieUpdateDto>>();
        builder.Services.AddTransient<IActorService, ActorsService>();
        builder.Services.AddTransient<IDirectorService, DirectorsService>();
        builder.Services.AddTransient<IWriterService, WriterService>();
        builder.Services.AddTransient<IProducerService, ProducerService>();
        builder.Services.AddTransient<IScheduleService, ScheduleService>();
        builder.Services.AddTransient<IGenresSerice, GenresService>();
        builder.Services.AddTransient<IHallService, HallService>();

        builder.Services.AddMvc().AddNewtonsoftJson();
        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
       
        });
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
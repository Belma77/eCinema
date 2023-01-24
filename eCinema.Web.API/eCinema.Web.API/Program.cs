using eCinema.Data;
using eCinema.Services;
using eCinema.Services.ActorService;
using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCinema.Services.CustomerServices;
using eCinema.Services.DirectorService;
using eCinema.Services.GenresServices;
using eCinema.Services.HallServices;
using eCinema.Services.MoviesServices;
using eCinema.Services.ProducerServices;
using eCinema.Services.Profiles;
using eCinema.Services.Resrevations;
using eCinema.Services.ScheduleServices;
using eCinema.Services.UserServices;
using eCinema.Services.WritersServices;
using eCinema.Web.API.Auth;
using eCinema.Web.API.Filters;
using eCInema.Models;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.SearchObjects;
using MediaBrowser.Model.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
        //builder.Services.AddControllers(x =>
        //{
        //    x.Filters.Add<ErrorFilter>();
        //});
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c=>
        {
            c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                Scheme = "basic"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
            }
        });
        });

        builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            
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
        builder.Services.AddTransient<ICustomerService, CustomerService>();
        builder.Services.AddTransient<IReservationService, ReservationService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<ErrorHandlingMiddleware>();
        builder.Services.AddMvc().AddNewtonsoftJson();
     
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
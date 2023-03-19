using AutoMapper;
using eCinema.Data;
using eCinema.Services.ActorService;
using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCinema.Services.DirectorService;
using eCinema.Services.ProducerServices;
using eCinema.Services.WritersServices;
using eCInema.Data.Entities;
using eCInema.Models;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace eCinema.Services.MoviesServices
{
    public class MoviesService : BaseCRUDService<MovieDetailsDto, Movies, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>, IMoviesService
    {
        private IActorService _actorService;
        private IDirectorService _directorService;
        private IWriterService _writerService;
        IProducerService _producerService;
        IHttpContextAccessor _accessor;
        
        public MoviesService(

            eCinemaContext context,
            IMapper mapper,
            IActorService actorService,
            IDirectorService directorService,
            IWriterService writerService,
            IProducerService producerService,
            IHttpContextAccessor httpContextAccessor

            ) : base(context, mapper)
        {
            _actorService = actorService;
            _directorService = directorService;
            _writerService = writerService;
            _producerService = producerService;
            _accessor = httpContextAccessor;
        }

        public override IQueryable<Movies> AddFilter(IQueryable<Movies> query, MoviesSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);
            if (!string.IsNullOrEmpty(search?.Title))
            {
                filteredQuery = query.Where(x => x.Title.StartsWith(search.Title));
            }

            return filteredQuery;
        }

        public override IQueryable<Movies> AddInclude(IQueryable<Movies> query, MoviesSearchObject search = null)
        {
            return query = query.Include(x => x.MoviesGenres)
                           .ThenInclude(s => s.Genre)
                           .Include(z => z.ActorsMovies)
                           .ThenInclude(a => a.Actor)
                           .Include(b => b.DirectorsMovies)
                           .ThenInclude(c => c.Director)
                           .Include(c => c.ProducersMovies)
                           .ThenInclude(c => c.Producer)
                           .Include(d => d.WritersMovies)
                           .ThenInclude(d => d.Writer);
        }

        public override MovieDetailsDto GetById(int id)
        {
            var movie = _context.Movies.
                Include(x => x.MoviesGenres)
                .ThenInclude(s => s.Genre)
                .Include(z => z.ActorsMovies)
                .ThenInclude(a => a.Actor)
                .Include(b => b.DirectorsMovies)
                .ThenInclude(c => c.Director)
                .Include(c => c.ProducersMovies)
                .ThenInclude(c => c.Producer)
                .Include(d => d.WritersMovies)
                .ThenInclude(d => d.Writer).
                 Include(x => x.Schedules).
                 FirstOrDefault(x => x.Id == id);

            return _mapper.Map<MovieDetailsDto>(movie);

        }

        public override MovieDetailsDto Insert(MovieInsertDto insert)
        {
            var entity = base.Insert(insert);
            var movie = _mapper.Map<Movies>(entity);


            foreach (var genre in insert.Genres)
            {
                var moviesGenres = new MoviesGenres
                {
                    MovieId = entity.Id,
                    GenreId = genre.Id
                };
                _context.MoviesGenres.Add(moviesGenres);
            }
            //add actors
            var actors = _mapper.Map<List<Actor>>(insert.Actors);
            _context.Actor.AddRangeIfNotExists(actors, _context);

            // add directors
            var directors = _mapper.Map<List<Director>>(insert.Directors);
            _context.Directors.AddRangeIfNotExists(directors, _context);

            //// add writers
            var writers = _mapper.Map<List<Writer>>(insert.Writers);
            _context.Writers.AddRangeIfNotExists(writers, _context);

            ////// add producers
            var producers = _mapper.Map<List<Producer>>(insert.Producers);
            _context.Producers.AddRangeIfNotExists(producers, _context);

            //// add actor-movie join entity
            foreach (var actor in insert.Actors)
            {
                var actorMovies = new ActorsMovies
                {
                    MovieId = entity.Id,
                    Actor = _context.Actor.FirstOrDefault(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName),
                };

                _context.ActorsMovies.Add(actorMovies);
            }

            //// add director-movie join entity
            foreach (var director in insert.Directors)
            {
                var directorMovies = new DirectorsMovies
                {
                    MovieId = entity.Id,
                    Director = _context.Directors.FirstOrDefault(x => x.FirstName == director.FirstName && x.LastName == director.LastName),
                };

                _context.DirectorsMovies.Add(directorMovies);
            }

            ////// add writer-movie join entity
            foreach (var writer in insert.Writers)
            {
                var writersMovies = new WritersMovies
                {
                    MovieId = entity.Id,
                    Writer = _context.Writers.FirstOrDefault(x => x.FirstName == writer.FirstName && x.LastName == writer.LastName),
                };

                _context.WritersMovies.Add(writersMovies);
            }

            ////// add producer-movie join entity
            foreach (var producer in insert.Producers)
            {
                var producerMovies = new ProducerMovies
                {
                    MovieId = entity.Id,
                    Producer = _context.Producers.FirstOrDefault(x => x.FirstName == producer.FirstName && x.LastName == producer.LastName),
                };

                _context.ProducersMovies.Add(producerMovies);
            }

            _context.SaveChanges();
            var response=GetById(entity.Id);
            return response;
        }

        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;
        static List<ProductEntry> data=null;
        public async Task<List<GetMoviesDto>> Recommend(int id)
        {
            TrainData();
            var user = _accessor.HttpContext.User.Identity.Name;
            var customerId = _context.Customers.FirstOrDefault(x => x.UserName == user).Id;
            var result=PredictMovies(customerId, id);
       
            return _mapper.Map<List<GetMoviesDto>>(result);
        }

        private List<Movies> PredictMovies(int customerId, int movieId)
        {
            List<uint> allItems = new List<uint>();

            var users = data.Where(x => x.MovieId == movieId).Select(x => x.UserId).ToList();

            var movies_list = new List<uint>();
            foreach (var item in users)
            {
                movies_list = data.Where(x => x.UserId == item && x.MovieId != movieId).Select(x => x.MovieId).Distinct().ToList();

            }
            for(int i=0; i<1000; i++)
            {
                allItems.AddRange(movies_list);
            }

            var predictionResult = new List<Tuple<Movies, float>>();

            foreach (var item in allItems)

            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    UserId = (uint)customerId,
                    MovieId = (uint)movieId,

                });
                var dbMovie = _context.Movies.FirstOrDefault(x => x.Id == item);
                predictionResult.Add(new Tuple<Movies, float>(dbMovie, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).DistinctBy(x=>x.Id).Take(3).ToList();
            return finalResult;
        }

        private void TrainData()
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();
                    var tmpData = _context.Reservations.Include(x => x.Customer).Include(x => x.Schedule).ThenInclude(y => y.Movie).ToList();

                    data = new List<ProductEntry>();
                    foreach (var res in tmpData)
                    {

                        data.Add(new ProductEntry()
                        {
                            MovieId = (uint)res.Schedule.MovieId,
                            UserId = (uint)res.CustomerId

                        });
                    }
                    mlContext = new MLContext();
                    var traindata = mlContext.Data.LoadFromEnumerable(data);
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.UserId);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.MovieId);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }
            }
        }


        public List<MovieSales> SalesByMovie()
        {
            var sales = _context.Reservations.Where(x => x.Status == eCInema.Models.Enums.ReservationStatusEnum.Paid)
                .Include(x => x.Schedule).ThenInclude(y => y.Movie)
               .GroupBy(y=>y.Schedule.Movie).
                    Select(x => new MovieSales
                    {
                        Movie = x.Key,
                        Sales = x.Sum(y => y.Price)
                    }).
                    ToList();
            return sales;
        }

        

        public class Copurchase_prediction
        {
            public float Score { get; set; }
        }

        public class ProductEntry
        {
            [KeyType(count: 10)]
            public uint UserId { get; set; }

            [KeyType(count: 10)]
            public uint MovieId { get; set; }

            public float Label { get; set; }
        }
    }
}


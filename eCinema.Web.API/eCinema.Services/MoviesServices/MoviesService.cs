using AutoMapper;
using eCinema.Data;
using eCinema.Services.ActorService;
using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCinema.Services.DirectorService;
using eCinema.Services.ProducerServices;
using eCinema.Services.WritersServices;
using eCInema.Data.Dtos;
using eCInema.Data.Entities;
using eCInema.Models;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.MoviesServices
{
    public class MoviesService:BaseCRUDService<MovieDetailsDto, Movies, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>, IMoviesService
    {
        private  IActorService _actorService;
        private IDirectorService _directorService;
        private IWriterService _writerService;
        IProducerService _producerService;

        public MoviesService(

            eCinemaContext context,
            IMapper mapper,
            IActorService actorService,
            IDirectorService directorService,
            IWriterService writerService,
            IProducerService producerService


            ) : base(context, mapper)
        {
            _actorService=actorService;
            _directorService = directorService;
            _writerService=writerService;
            _producerService = producerService;
        }

        public override  IQueryable<Movies> AddFilter(IQueryable<Movies> query, MoviesSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);
            if(!string.IsNullOrEmpty(search?.Title))
            {
                filteredQuery = query.Where(x => x.Title.StartsWith(search.Title));
            }

            return filteredQuery;
        }

        public override IQueryable<Movies> AddInclude(IQueryable<Movies> query, MoviesSearchObject search = null)
        {
            return query = query.Include(x => x.MoviesGenres)
                           .ThenInclude(s=>s.Genre)
                           .Include(z => z.ActorsMovies)
                           .ThenInclude(a => a.Actor)
                           .Include(b => b.DirectorsMovies)
                           .ThenInclude(c=>c.Director)
                           .Include(c => c.ProducersMovies)
                           .ThenInclude(c=>c.Producer)
                           .Include(d => d.WritersMovies)
                           .ThenInclude(d=>d.Writer);
        }

        public override MovieDetailsDto GetById(int id)
        {
            var query =base.Get();
            var movie = query.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<MovieDetailsDto>(movie);
            
        }

        public override MovieDetailsDto Update(int id, MovieUpdateDto update)
        {
            var entity = base.Update(id, update);

            if (update.Actors != null)
            {
                var actors = _mapper.Map<List<Actor>>(update?.Actors);
                _context.Actor.AddRangeIfNotExists(actors, _context);
                foreach (var actor in update.Actors)
                {
                    var actorMoviesExists = _context.ActorsMovies.Where(x => x.Actor.Equals(actor) && id == x.MovieId);
                    if (actorMoviesExists == null)
                    {
                        var actorMovies = new ActorsMovies
                        {
                            MovieId = entity.Id,
                            Actor = _context.Actor.FirstOrDefault(x => x.FirstName == actor.Actor.FirstName && x.LastName == actor.Actor.LastName),
                        };

                        _context.ActorsMovies.Add(actorMovies);
                        _context.SaveChanges();
                    }
                }
            }

            //if (update.Directors != null)
            //{
            //    // add directors
            //    var directors = _mapper.Map<List<Director>>(update?.Directors);
            //    _context.Directors.AddRangeIfNotExists(directors, _context);
            //}

            //if (update.Writers != null)
            //{
            //    // add writers
            //    var writers = _mapper.Map<List<Writer>>(update?.Writers);
            //    _context.Writers.AddRangeIfNotExists(writers, _context);
            //}

            //if (update.Producers != null)
            //{
            //    //// add producers
            //    var producers = _mapper.Map<List<Producer>>(update?.Producers);
            //    _context.Producers.AddRangeIfNotExists(producers, _context);
            //}
           

            //// add director-movie join entity
            //foreach (var director in update.Directors)
            //{
            //    var directorMovies = new DirectorsMovies
            //    {
            //        MovieId = entity.Id,
            //        Director = _context.Directors.FirstOrDefault(x => x.FirstName == director.FirstName && x.LastName == director.LastName),
            //    };

            //    _context.DirectorsMovies.Add(directorMovies);
            //}

            ////// add writer-movie join entity
            //foreach (var writer in update.Writers)
            //{
            //    var writersMovies = new WritersMovies
            //    {
            //        MovieId = entity.Id,
            //        Writer = _context.Writers.FirstOrDefault(x => x.FirstName == writer.FirstName && x.LastName == writer.LastName),
            //    };

            //    _context.WritersMovies.Add(writersMovies);
            //}

            ////// add producer-movie join entity
            //foreach (var producer in update.Producers)
            //{
            //    var producerMovies = new ProducerMovies
            //    {
            //        MovieId = entity.Id,
            //        Producer = _context.Producers.FirstOrDefault(x => x.FirstName == producer.FirstName && x.LastName == producer.LastName),
            //    };

            //    _context.ProducersMovies.Add(producerMovies);
            //}

            //_context.SaveChanges();
            return GetById(id);

        }

        
        public override MovieDetailsDto Insert(MovieInsertDto insert)
        {
            var entity= base.Insert(insert);
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
            return GetById(entity.Id);
        }

        
    }
}

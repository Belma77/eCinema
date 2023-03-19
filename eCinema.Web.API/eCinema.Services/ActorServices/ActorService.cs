using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCInema.Models.SearchObjects;
using eCInema.Models.Dtos.Movie;

namespace eCinema.Services.ActorService
{
    public class ActorsService: IActorService
    {
        eCinemaContext _context;
        IMapper _mapper;

        public ActorsService(eCinemaContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper; 
        }


        public List<ActorDto> Add(int id, List<ActorDto> insert)
        {
           var actors=  _mapper.Map<List<Actor>>(insert);
            _context.Actor.AddRangeIfNotExists(actors, _context);
            AddActorsToMovie(id, actors);
            return insert;
        }

        public List<Actor> AddActorsToMovie(int MovieId, List<Actor> insert)
        {
            var actors = _context.Actor.ToList();

            foreach (var actor in insert)
            {
                var actorsMovies = new ActorsMovies();
                actorsMovies.MovieId = MovieId;
                actorsMovies.Actor = actors.FirstOrDefault(x=>x.Equals(actor));
                _context.ActorsMovies.AddIfNotExists(actorsMovies, _context);

            }
            return actors;
        }


        public void DeleteActorsMovies(List<ActorsMoviesDto> delete)
        {
            var mapped = _mapper.Map<List<ActorsMovies>>(delete);
            foreach (var item in mapped)
            {
                var find = _context.ActorsMovies.FirstOrDefault(x => x.Actor.FirstName.ToLower() == item.Actor.FirstName.ToLower() && x.Actor.LastName.ToLower() == item.Actor.LastName.ToLower() && x.MovieId == item.MovieId);
                if (find != null)
                {
                    _context.ActorsMovies.Remove(find);
                    _context.SaveChangesAsync();
                }
            }
        }

    }
}

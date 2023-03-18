using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCinema.Services.CastServices;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCInema.Models.SearchObjects;

namespace eCinema.Services.ActorService
{
    public class ActorsService: BaseCRUDService<ActorDto, Actor, CastSearchObject, ActorDto, ActorUpdateDto>, IActorService
    {
       
        public ActorsService(eCinemaContext context, IMapper mapper):base(context, mapper)
        {
            
        }

        public override ActorDto Insert(ActorDto insert)
        {
            var actors = _mapper.Map<Actor>(insert);
            _context.Actor.AddIfNotExists(actors, _context);

            return insert;
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


        public ActorDto Update(int id, ActorDto actor)
        {
            return actor;
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

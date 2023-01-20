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

namespace eCinema.Services.ProducerServices
{
    public class ProducerService: BaseCRUDService<ProducersMoviesDto, Producer, CastSearchObject, ProducersMoviesDto, ProducersMoviesDto>, IProducerService
    {
        private eCinemaContext _context;
        private IMapper _mapper;

        public ProducerService(eCinemaContext context, IMapper mapper):base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProducerDto> Add(int id, List<ProducerDto> insert)
        {
            var producers = _mapper.Map<List<Producer>>(insert);
            _context.Producers.AddRangeIfNotExists(producers, _context);
            AddProducersToMovie(id, producers);
            return insert;
        }

        public void AddProducersToMovie(int MovieId, List<Producer>insert )
        {
            var producers = _context.Producers.ToList();

            foreach (var producer in insert)
            {
                var producerMovies = new ProducerMovies();
                producerMovies.MovieId = MovieId;
                producerMovies.Producer = producers.FirstOrDefault(x=>x.Equals(producer));
                _context.ProducersMovies.AddIfNotExists(producerMovies, _context);

            }
        }

        public void DeleteProducersMovies(List<ProducersMoviesDto> delete)
        {
            var mapped = _mapper.Map<List<ProducerMovies>>(delete);
            foreach(var item in mapped)
            {
                var find = _context.ProducersMovies.FirstOrDefault(x => x.Producer.FirstName==item.Producer.FirstName&&x.Producer.LastName==item.Producer.LastName && x.MovieId == item.MovieId);
                if (find != null)
                {
                    _context.ProducersMovies.Remove(find);
                    _context.SaveChanges();
                }
            }
            //_context.ProducersMovies.RemoveRangeIfExists(find, _context);
        }

    }
}

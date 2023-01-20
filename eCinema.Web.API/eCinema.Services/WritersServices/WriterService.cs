using AutoMapper;
using eCinema.Data;
using eCinema.Services.CastServices;
using eCInema.Models.Dtos;
using eCinema.Services.CRUDservice;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.WritersServices
{
    public class WriterService: BaseCRUDService<WriterDto,Writer, CastSearchObject, WriterDto, WriterDto>, IWriterService
    {
        public WriterService(eCinemaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<WriterDto> Add(int id, List<WriterDto> insert)
        {
            var writers = _mapper.Map<List<Writer>>(insert);
            _context.Writers.AddRangeIfNotExists(writers, _context);
            AddWritersToMovie(id, writers);
            return insert;
        }

        public void AddWritersToMovie(int MovieId, List<Writer> insert )
        {
            var writers = _context.Writers.ToList();

            foreach (var writer in insert)
            {
                var writersMovies = new WritersMovies();
                writersMovies.MovieId = MovieId;
                writersMovies.Writer = writers.FirstOrDefault(x=>x.Equals(writer));
                _context.WritersMovies.AddIfNotExists(writersMovies, _context);

            }
        }
         
        public void DeleteWritersMovies(List<WritersMoviesDto> delete)
        {

            var mapped = _mapper.Map<List<WritersMovies>>(delete);
            foreach (var item in mapped)
            {
                var find = _context.WritersMovies.FirstOrDefault(x => x.Writer.FirstName.ToLower() == item.Writer.FirstName.ToLower() && x.Writer.LastName.ToLower() == item.Writer.LastName.ToLower() && x.MovieId == item.MovieId);
                if (find != null)
                {
                    _context.WritersMovies.Remove(find);
                    _context.SaveChanges();
                }
            }
            // _context.WritersMovies.RemoveRangeIfExists(find, _context);
        }

    }
}

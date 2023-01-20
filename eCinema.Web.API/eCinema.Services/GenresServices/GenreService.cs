using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Data.Entities;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.GenresServices
{
    public class GenresService:BaseCRUDService<GenresDto, Genres, GenresDto, GenresDto, GenresDto>, IGenresSerice
    {

        public GenresService(eCinemaContext context, IMapper mapper):base(context, mapper)
        {

        }

        public List<MoviesGenresUpdateDto> DeleteMoviesGenres(List<MoviesGenresUpdateDto> delete)
        {
            var mapped=_mapper.Map<List<MoviesGenres>>(delete);
            var genres = _context.MoviesGenres;

            foreach(var item in mapped)
            {
                var find=genres.FirstOrDefault(x=>x.MovieId == item.MovieId&&x.Equals(item));
                if(find!=null)
                {
                    _context.MoviesGenres.Remove(find);
                    _context.SaveChanges();
                }
            }
            return delete;
        }

        public void AddGenresToMovie(int MovieId, List<GenresDto> insert)
        {
            var genres = _context.MoviesGenres.ToList();
            var mapped=_mapper.Map<List<Genres>>(insert);

            foreach (var item in mapped)
            {
                var find = genres.Where(x => x.Equals(item)).FirstOrDefault();
                if (find == null)
                {
                    var moviesGenres=new MoviesGenres();
                    moviesGenres.MovieId = MovieId;
                    moviesGenres.GenreId = item.Id;
                    _context.MoviesGenres.Add(moviesGenres);
                    _context.SaveChanges();
                }

            }
        }
    }
}

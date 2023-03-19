using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.DirectorService
{
    public class DirectorsService: IDirectorService
    {
        private eCinemaContext _context;
        private IMapper _mapper;
        public DirectorsService(eCinemaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DirectorDto> Add(int id, List<DirectorDto> insert)
        {
            var directors = _mapper.Map<List<Director>>(insert);
            _context.Directors.AddRangeIfNotExists(directors, _context);
            AddDirectorsToMovie(id, directors);
            return insert;
        }

        public void AddDirectorsToMovie(int MovieId, List<Director> insert)
        {
            var directors = _context.Directors.ToList();

            foreach (var director in insert)
            {
                var directorsMovies = new DirectorsMovies();
                directorsMovies.MovieId = MovieId;
                directorsMovies.Director = directors.FirstOrDefault(x=>x.Equals(director));
                _context.DirectorsMovies.AddIfNotExists(directorsMovies, _context);
            }
        }

        public void DeleteDirectorsMovies(List<DirectorsMoviesDto> delete)
        {
            var mapped = _mapper.Map<List<DirectorsMovies>>(delete);
            foreach (var item in mapped)
            {
                var find = _context.DirectorsMovies.FirstOrDefault(x => x.Director.FirstName.ToLower() == item.Director.FirstName.ToLower() && x.Director.LastName.ToLower() == item.Director.LastName.ToLower() && x.MovieId == item.MovieId);
                if (find != null)
                {
                    _context.DirectorsMovies.Remove(find);
                    _context.SaveChanges();
                }
            }
        }
       
    }
    
}

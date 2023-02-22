using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCInema.Models;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.MoviesServices
{
    public interface IMoviesService:IBaseCRUDService<MovieDetailsDto, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>
    {
        //void DeleteDirectorsMovies(DirectorsMoviesDto delete);
        List<GetMoviesDto> Recommend(int id);
    }
}

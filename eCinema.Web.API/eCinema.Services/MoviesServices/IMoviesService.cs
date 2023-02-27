using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCInema.Models;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCinema.Services.MoviesServices.MoviesService;

namespace eCinema.Services.MoviesServices
{
    public interface IMoviesService:IBaseCRUDService<MovieDetailsDto, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>
    {
        List<GetMoviesDto> Recommend(int id);
        public List<MovieSales> SalesByMovie();
    }
}

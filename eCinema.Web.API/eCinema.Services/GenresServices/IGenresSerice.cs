using eCinema.Services.CRUDservice;
using eCInema.Data.Entities;
using eCInema.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.GenresServices
{
    public interface IGenresSerice:IBaseCRUDService<GenresDto, GenresDto, GenresDto, GenresDto>
    {
        List<MoviesGenresUpdateDto> DeleteMoviesGenres(List<MoviesGenresUpdateDto> delete);
        void AddGenresToMovie(int MovieId, List<GenresDto> insert);
    }
}

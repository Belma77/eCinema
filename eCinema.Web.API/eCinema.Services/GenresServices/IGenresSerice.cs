using eCinema.Services.CRUDservice;
using eCInema.Data.Entities;
using eCInema.Models.Dtos;
using eCInema.Models.Dtos.Genres;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.GenresServices
{
    public interface IGenresSerice:IBaseCRUDService<GenresDto, GenresSearchObject, GenresUpsertDto, GenresUpsertDto>
    {
        List<MoviesGenresUpdateDto> DeleteMoviesGenres(List<MoviesGenresUpdateDto> delete);
        void AddGenresToMovie(int MovieId, List<GenresDto> insert);
    }
}

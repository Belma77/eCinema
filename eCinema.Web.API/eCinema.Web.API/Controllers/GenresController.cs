using eCinema.Services.GenresServices;
using eCInema.Data.Entities;
using eCInema.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Genres")]
    [ApiController]
    public class GenresController : BaseCRUDController<GenresDto, GenresDto, GenresDto, GenresDto>
    {
        IGenresSerice _service;
        public GenresController(IGenresSerice service) : base(service)
        {
            _service = service;
        }

        [HttpDelete]
        public List<MoviesGenresUpdateDto> Delete(List<MoviesGenresUpdateDto> delete)
        {
            return _service.DeleteMoviesGenres(delete);
        }

        [HttpPost("{id}")]
        public void AddGenresToMovie(int id, List<GenresDto> insert)
        {
            _service.AddGenresToMovie(id, insert);
        }
    }
}

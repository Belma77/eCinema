using eCinema.Services.MoviesServices;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MoviesController : BaseCRUDController<MovieDetailsDto, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>
    {
        IMoviesService _service;
        public MoviesController(IMoviesService service) : base(service)
        {
            _service=service;
        }

        //[HttpDelete]
        //[Route("Directors")]
        //public void Delete(DirectorsMoviesDto delete)
        //{
        //    _service.DeleteDirectorsMovies(delete);
        //}

    }
}

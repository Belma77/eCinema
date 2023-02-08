using eCinema.Services.MoviesServices;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

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

        //[AllowAnonymous]
        [Authorize(UserRole.Admin, UserRole.Customer)]
        public override IActionResult Get([FromQuery] MoviesSearchObject? search = null)
        {
            return base.Get(search);
        }

        //[AllowAnonymous]
        [Authorize(UserRole.Admin, UserRole.Customer)]
        public override IActionResult GetById(int id)
        {
            return base.GetById(id);
        }

        [HttpGet("{id}/Recommend")]
        [AllowAnonymous]
        public List<MovieDetailsDto> Recommend(int id)
        {
            return _service.Recommend(id);
        }
    }
}

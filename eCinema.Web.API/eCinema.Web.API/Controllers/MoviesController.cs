using eCinema.Services.MoviesServices;
using eCInema.Models.Dtos.Movie;
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
   // [Authorize(UserRole.Admin)]
    public class MoviesController : BaseCRUDController<MovieDetailsDto, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>
    {
        IMoviesService _service;
        public MoviesController(IMoviesService service) : base(service)
        {
            _service=service;
        }


        public override async Task<IActionResult> Get([FromQuery] MoviesSearchObject? search = null)
        {
            return await base.Get(search);
        }

        [Authorize(UserRole.Customer, UserRole.Admin)]
        public async override Task<IActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [HttpGet("{id}/Recommend")]
        [Authorize(UserRole.Customer)]
        public async Task<List<GetMoviesDto>> Recommend(int id)
        {
            return await _service.Recommend(id);
        }

        [HttpGet("Sales")]
        [AllowAnonymous]
        public IActionResult SalesPerMovie()
        {
            return Ok(_service.SalesByMovie());
        }

    }
}

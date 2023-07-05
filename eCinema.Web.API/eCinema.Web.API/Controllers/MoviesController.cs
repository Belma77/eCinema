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
    public class MoviesController : BaseCRUDController<MovieDetailsDto, MoviesSearchObject, MovieInsertDto, MovieUpdateDto>
    {
        IMoviesService _service;
        public MoviesController(IMoviesService service) : base(service)
        {
            _service=service;
        }

        [Authorize(UserRole.Admin)]
        [HttpGet]
        public override IActionResult Get([FromQuery] MoviesSearchObject? search = null)
        {
            return base.Get(search);
        }

        [HttpGet("{id}")]
        [Authorize(UserRole.Customer, UserRole.Admin)]
        public override IActionResult GetById(int id)
        {
            return base.GetById(id);
        }
        [HttpPost]
        [Authorize(UserRole.Admin)]
        public override IActionResult Insert(MovieInsertDto insert)
        {
            return base.Insert(insert);
        }
        [HttpPut("{id}")]
        [Authorize(UserRole.Admin)]
        public override IActionResult Update (int id, MovieUpdateDto update)
        {
            return base.Update(id, update);
        }

        [HttpDelete("{id}")]
        [Authorize(UserRole.Admin)]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpGet("{id}/Recommend")]
        [Authorize(UserRole.Customer)]
        public async Task<List<GetMoviesDto>> Recommend(int id)
        {
            return await _service.Recommend(id);
        }

        [HttpGet("Sales")]
        [Authorize(UserRole.Admin)]
        public IActionResult SalesPerMovie([FromQuery]  SalesPerMovieSearchObject? search=null)
        {
            return Ok(_service.SalesByMovie(search));
        }

       

    }
}

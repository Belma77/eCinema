using eCinema.Services.ActorService;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Actors")]
    [ApiController]
    [Authorize(UserRole.Admin)]
    public class ActorsController : ControllerBase 
    {
        IActorService _service;
        public ActorsController(IActorService service) : base()
        {
            _service=service;   
        }

        [HttpPost("AddToMovie/{id}")]
        public void Add(int id, List<ActorDto> insert)
        {
             _service.Add(id, insert);
        }

        [HttpDelete("FromMovie")]
        public void Delete(List<ActorsMoviesDto> delete)
        {
            _service.DeleteActorsMovies(delete);
        }
    }
}

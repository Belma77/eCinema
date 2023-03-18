using eCinema.Services.ActorService;
using eCinema.Services.CastServices;
using eCinema.Services.DirectorService;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Bson;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Directors")]
    [ApiController]
    [Authorize(UserRole.Admin)]
    public class DirectorsController : ControllerBase
    {

        IDirectorService _service;
        public DirectorsController(IDirectorService service) : base()
        {
            _service = service;
        }

        [HttpPost("AddToMovie/{id}")]
        public void Add(int id, List<DirectorDto> insert)
        {
            _service.Add(id, insert);
        }


        [HttpDelete("FromMovie")]
        public void Delete(List<DirectorsMoviesDto> delete)
        {
            _service.DeleteDirectorsMovies(delete);
        }
    }
}

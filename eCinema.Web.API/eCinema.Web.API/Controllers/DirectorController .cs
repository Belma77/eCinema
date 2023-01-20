using eCinema.Services.ActorService;
using eCinema.Services.CastServices;
using eCinema.Services.DirectorService;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Bson;

namespace eCinema.Web.API.Controllers
{
    [Route("Directors")]
    [ApiController]
    public class DirectorsController : BaseCRUDController<DirectorDto, CastSearchObject, DirectorDto, DirectorDto>
    {

        IDirectorService _service;
        public DirectorsController(IDirectorService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("{id}")]
        public void Add(int id, List<DirectorDto> insert)
        {
            _service.Add(id, insert);
        }


        [HttpDelete]
        public void Delete(List<DirectorsMoviesDto> delete)
        {
            _service.DeleteDirectorsMovies(delete);
        }
    }
}

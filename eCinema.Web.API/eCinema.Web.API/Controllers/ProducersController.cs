using eCinema.Services.ActorService;
using eCinema.Services.ProducerServices;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Producers")]
    [ApiController]
    [Authorize(UserRole.Admin)]

    public class ProducersController : ControllerBase
    {
        IProducerService _service;
        public ProducersController(IProducerService service) : base()
        {
            _service=service;   
        }

        [HttpPost("AddToMovie/{id}")]
        public void Add(int id, List<ProducerDto> insert)
        {
             _service.Add(id, insert);
        }

        [HttpDelete("FromMovie")]
        public void Delete(List<ProducersMoviesDto> delete)
        {
            _service.DeleteProducersMovies(delete);
        }
    }
}

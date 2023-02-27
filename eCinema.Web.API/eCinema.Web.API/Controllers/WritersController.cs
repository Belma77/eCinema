using eCinema.Services.ActorService;
using eCinema.Services.WritersServices;
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
    [Route("Writers")]
    [ApiController]
    [Authorize(UserRole.Admin)]

    public class WritersController : ControllerBase
    {

        IWriterService _service;
        public WritersController(IWriterService service) : base()
        {
            _service=service;   
        }

        [HttpPost("AddToMovie/{id}")]
        public void Add(int id, List<WriterDto> insert)
        {
             _service.Add(id, insert);
        }

        [HttpDelete("FromMovie")]
        public void Delete(List<WritersMoviesDto> delete)
        {
            _service.DeleteWritersMovies(delete);
        }
    }
}

using eCinema.Services.ActorService;
using eCinema.Services.WritersServices;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Writers")]
    [ApiController]
    public class WritersController : BaseCRUDController<WriterDto, CastSearchObject, WriterDto, WriterDto>
    {

        IWriterService _service;
        public WritersController(IWriterService service) : base(service)
        {
            _service=service;   
        }

        [HttpPost("{id}")]
        public void Add(int id, List<WriterDto> insert)
        {
             _service.Add(id, insert);
        }

        [HttpDelete]
        public void Delete(List<WritersMoviesDto> delete)
        {
            _service.DeleteWritersMovies(delete);
        }
    }
}

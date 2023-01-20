using eCinema.Services.ActorService;
using eCinema.Services.ProducerServices;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Producers")]
    [ApiController]
    public class ProducersController : BaseCRUDController<ProducersMoviesDto, CastSearchObject, ProducersMoviesDto, ProducersMoviesDto>
    {
        IProducerService _service;
        public ProducersController(IProducerService service) : base(service)
        {
            _service=service;   
        }

        [HttpPost("{id}")]
        public void Add(int id, List<ProducerDto> insert)
        {
             _service.Add(id, insert);
        }

        [HttpDelete]
        public void Delete(List<ProducersMoviesDto> delete)
        {
            _service.DeleteProducersMovies(delete);
        }
    }
}

using eCinema.Services.HallServices;
using eCInema.Models.Dtos.Hall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Hall")]
    [ApiController]
    public class HallController : BaseCRUDController<HallDto, HallDto, HallDto, HallUpdateDto>
    {
        public HallController(IHallService service):base(service)
        {

        }
    }
}

using eCinema.Services.BaseService;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Tmodel, TSearchObject> : ControllerBase where Tmodel : class where TSearchObject : class
    {
        protected IBaseService<Tmodel, TSearchObject> _service;

        public BaseController(IBaseService<Tmodel, TSearchObject> service)
        {
            _service = service; 
        }

        [HttpGet]
        public virtual IActionResult Get([FromQuery]TSearchObject? search=null)
        {
            return Ok(_service.Get(search));
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        
    }
}

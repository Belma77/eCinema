using AutoMapper;
using eCinema.Data;
using eCinema.Services.ScheduleServices;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Schedule")]
    [ApiController]
    
    public class ScheduleController : BaseCRUDController<GetSchedulesDto, ScheduleSearchObject, ScheduleInsertDto, ScheduleUpdateDto>
    {
        public ScheduleController(IScheduleService service):base(service)
        {

        }

        [AllowAnonymous]
        [Authorize(UserRole.Admin, UserRole.Customer)]
        public override Task<IActionResult> Get([FromQuery] ScheduleSearchObject? search = null)
        {
            return base.Get(search);
        }

        [AllowAnonymous]
        [Authorize(UserRole.Admin, UserRole.Customer)]
        [HttpGet("{id}")]
        public async override Task<IActionResult> GetById(int id)
        {
            
             return await base.GetById(id);
            
        }
    }
}

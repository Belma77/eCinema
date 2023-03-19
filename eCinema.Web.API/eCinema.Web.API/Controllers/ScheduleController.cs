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
        IScheduleService scheduleService;
        public ScheduleController(IScheduleService service):base(service)
        {
            scheduleService = service;
        }

        [Authorize(UserRole.Admin, UserRole.Customer)]
        [HttpGet]
        public override IActionResult Get([FromQuery] ScheduleSearchObject? search = null)
        {
            return base.Get(search);
        }

        [Authorize(UserRole.Admin, UserRole.Customer)]
        [HttpGet("{id}")]
        public override IActionResult GetById(int id)
        {           
             return base.GetById(id);           
        }

        [Authorize(UserRole.Admin)]
        [HttpGet("{id}/Seats")]
        public IActionResult GetSeats(int id)
        {
            return Ok(scheduleService.GetSeats(id));
        }

        [Authorize(UserRole.Admin)]
        [HttpPost]
        public override IActionResult Insert(ScheduleInsertDto insert)
        {
            return base.Insert(insert);
        }

        [Authorize(UserRole.Admin)]
        [HttpPut("{id}")]
        public override IActionResult Update(int id, ScheduleUpdateDto update)
        {
            return base.Update(id, update);
        }

        [Authorize(UserRole.Admin)]
        [HttpDelete("{id}")]

        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpGet("Distinct")]
        [Authorize(UserRole.Admin)]
        public IActionResult GetDistinct()
        {
            return Ok(scheduleService.GetDistinct());
        }
    }
}

using AutoMapper;
using eCinema.Data;
using eCinema.Services.ScheduleServices;
using eCInema.Data.Dtos;
using eCInema.Models.Dtos.Schedule;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Schedule")]
    [ApiController]

    public class ScheduleController : BaseCRUDController<GetSchedulesDto, ScheduleSearchObject, ScheduleInsertDto, ScheduleUpdateDto>
    {
        public ScheduleController(IScheduleService service):base(service)
        {

        }



    }
}

using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Dtos.SchedulesSeats;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.ScheduleServices
{
    public interface IScheduleService:IBaseCRUDService<GetSchedulesDto, ScheduleSearchObject, ScheduleInsertDto, ScheduleUpdateDto>
    {
        List<GetSchedulesDto> GetDistinct();
        //List<ScheduleSeatDto> GetSeats(int id);
        GetSchedulesDto GetSeats(int id);
    }
}

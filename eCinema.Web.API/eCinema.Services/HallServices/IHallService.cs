using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Halls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.HallServices
{
    public interface IHallService:IBaseCRUDService<HallDto, HallDto, HallDto, HallUpdateDto>
    {
        
    }
}

using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Halls;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCinema.Services.BaseService;
namespace eCinema.Services.HallServices
{
    public interface IHallService:IBaseService<HallDto, HallSearchObject>
    {
        
    }
}

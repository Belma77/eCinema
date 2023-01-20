using eCinema.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CRUDservice
{
    public interface IBaseCRUDService<Tmodel, TSearch, TInsert, TUpdate>:IBaseService<Tmodel, TSearch> where Tmodel : class where TSearch : class  where TInsert : class where TUpdate : class 
    {
       Tmodel Insert(TInsert insert);
       Tmodel Update(int id,TUpdate update);
       List<Tmodel> Delete(int id);
    }
}

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
       Task<Tmodel> InsertAsync(TInsert insert);
       Task<Tmodel> UpdateAsync(int id,TUpdate update);
       Task<List<Tmodel>> DeleteAsync(int id);
    }
}

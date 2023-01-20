using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.BaseService
{
    public interface IBaseService<Tmodel, Tsearch> where Tmodel : class where Tsearch : class
    {
        List<Tmodel> Get(Tsearch? search=null);
        Tmodel GetById(int id);
    }

}

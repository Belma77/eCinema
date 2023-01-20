using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CastServices
{
    public interface ICastService<TDatabase> where TDatabase : class
    {
        List<TDatabase> Add(List<TDatabase> list);
    }
}

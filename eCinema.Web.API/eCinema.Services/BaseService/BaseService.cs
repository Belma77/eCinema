using AutoMapper;
using eCinema.Data;
using eCinema.Services.BaseService;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace eCinema.Services
{
    public class BaseService<Tmodel, TDatabase, TSearchObject>:IBaseService<Tmodel, TSearchObject> where Tmodel : class where TSearchObject : class where TDatabase:class
    {
        protected IMapper _mapper;

        protected eCinemaContext _context;

        public BaseService( eCinemaContext context, IMapper mapper)
        {
            _mapper = mapper;
           _context = context;
             
        }

        public virtual List<Tmodel> Get(TSearchObject? search =null)
        {
            var query = _context.Set<TDatabase>().AsQueryable();

           query = AddFilter(query, search);

            query= AddInclude(query, search);

            var list=query.ToList();
            
            return _mapper.Map<List<Tmodel>>(list);
        }

        
        public virtual IQueryable<TDatabase> AddFilter(IQueryable<TDatabase> query, TSearchObject search=null)
        {
            return query;
        }

        public virtual IQueryable<TDatabase> AddInclude(IQueryable<TDatabase> query, TSearchObject search = null)
        {
            return query;
        }

        public virtual Tmodel GetById(int id)
        {
            var set=_context.Set<TDatabase>();
            var entity = set.Find(id);
            return _mapper.Map<Tmodel>(entity);

        }
    }
}

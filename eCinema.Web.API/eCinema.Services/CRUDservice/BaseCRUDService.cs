using AutoMapper;
using eCinema.Data;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CRUDservice
{
    public class BaseCRUDService<Tmodel, TDatabase, TSearchObject, TInsert, TUpdate>
        :BaseService<Tmodel, TDatabase, TSearchObject>, IBaseCRUDService<Tmodel,TSearchObject, TInsert, TUpdate>
        where Tmodel:class where TDatabase:class where TSearchObject:BaseSearchObject where TInsert : class where TUpdate : class
    {
      
        public BaseCRUDService(eCinemaContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public virtual Tmodel Insert(TInsert insert)
        {
            var set = _context.Set<TDatabase>();

            var entity = _mapper.Map<TDatabase>(insert);

            BeforeInsert(insert, entity);

            set.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<Tmodel>(entity);           
        }

        public virtual void BeforeInsert(TInsert insert, TDatabase entity)
        {
            
        }


        public virtual List<Tmodel> Add(List<Tmodel> list)
        {
            var context = _context.Set<TDatabase>().ToList();
            var items = _mapper.Map<List<TDatabase>>(list);
            foreach (var item in items)
            {
                if (!context.Contains(item))
                {
                    context.Add(item);
                    _context.SaveChanges();
                }
            }
            return list;
        }

        
        public virtual Tmodel Update(int id, TUpdate update)
        {
            var set = _context.Set<TDatabase>();

            var entity = set.Find(id);

            if (entity != null)
            {
                _mapper.Map(update, entity);
            }
            else
            {
                return null;
            }

            _context.SaveChanges();

            return _mapper.Map<Tmodel>(entity);
        }

        public virtual List<Tmodel> Delete(int id)
        {
            var set = _context.Set<TDatabase>();

            var entity = set.Find(id);

            if(entity!=null)
            {
                set.Remove(entity);
                _context.SaveChanges();
            }
            return _mapper.Map<List<Tmodel>>(set);
           
        }
    }
}

using eCinema.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DbSetExtensions
{
   
    public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, eCinemaContext context) where T : class, new()
    {
        var list = dbSet.ToList();
        if (!list.Contains(entity))
            dbSet.Add(entity);
    
       
        context.SaveChanges();
        return entity;
    }

    public static List<T> AddRangeIfNotExists<T>(this DbSet<T> dbSet, List<T> entities, eCinemaContext _context) where T : class, new()
    {
        List<T> added = new();
        var list=dbSet.ToList();

        foreach (var entity in entities)
        {
            if (!list.Contains(entity))
                added.Add(entity);
        }

        _context.AddRange(added);
        _context.SaveChanges();
        return added;
    }

    public static List<T> RemoveIfExists<T>(this DbSet<T> dbSet, T entity, eCinemaContext _context) where T : class, new()
    {
        dbSet.Remove(entity);
        _context.SaveChanges();
        return dbSet.ToList();
    }

    public static List<T> RemoveRangeIfExists<T>(this DbSet<T> dbSet, List<T> entity, eCinemaContext _context) where T : class, new()
    {
        var list= dbSet.ToList();  
        var remove=new List<T>();

        foreach(var item in entity)
        {
            if (list.Contains(item))
            {
                remove.Add(item);   
                dbSet.Remove(item);
            }
        }

        _context.SaveChanges();

        return remove;

    }
   
}

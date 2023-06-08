using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity,TContext> : 
        IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
       


    {
       

        public void create(TEntity entity)
        {

            using (var context=new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
       
            
        }

        public void delete(TEntity entity)
        {

            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();

            }
    
            
        }

        public List<TEntity> GetAll()
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().ToList();
            }   
           
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
               
            
        }

        public void update(TEntity entity)
        {

            using (var context=new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
               
            
               

        }
    }
}

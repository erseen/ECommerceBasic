using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);  
        List<T> GetAll();
        void create(T entity); 
        void update(T entity);
        void delete(T entity);


    }
}

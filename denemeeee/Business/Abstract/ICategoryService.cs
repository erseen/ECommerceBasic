using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        void create(Category entity);
        void update(Category entity);
        void delete(Category entity);
       
    }
}

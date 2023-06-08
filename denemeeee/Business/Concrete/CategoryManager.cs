using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void create(Category entity)
        {
            _categoryRepository.create(entity);
        }

        public void delete(Category entity)
        {
            _categoryRepository.delete(entity);
        }

        public List<Category> GetAll()
        {
          return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
           return  _categoryRepository.GetById(id);
        }

      
        public void update(Category entity)
        {
            _categoryRepository.update(entity); 
        }
    }
}

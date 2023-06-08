using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductRepository _productRepository; 
        public ProductManager(IProductRepository productRepository)
        {
             _productRepository = productRepository;
        }

        public void create(Product entity)
        {
            _productRepository.create(entity);
        }

        public void delete(Product entity)
        {
            _productRepository.delete(entity);  

        }

        public List<Product> GetAll()
        {
         return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public int GetCountProductByCategory(int id)
        {
          return _productRepository.GetCountProductByCategory(id);
        }

        public List<Product> GetProductsByCategory(int id, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(id,page,pageSize);
        }

        public List<Product> GetSearchResult(string searchResult)
        {
            return _productRepository.GetSearchResult(searchResult);

        }

        public void update(Product entity)
        {
            _productRepository.update(entity);

        }
    }
}

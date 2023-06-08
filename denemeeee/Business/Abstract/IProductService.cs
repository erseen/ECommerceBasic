using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int id, int page, int pageSize);
        List<Product> GetSearchResult(string searchResult);
        int GetCountProductByCategory(int id);
        void create(Product entity);
        void update(Product entity);
        void delete(Product entity);

    }
}

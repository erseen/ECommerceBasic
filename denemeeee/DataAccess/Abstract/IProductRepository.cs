using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<Product> GetProductsByCategory(int id,int page,int pageSize);
        List<Product> GetSearchResult(string searchResult);
        int GetCountProductByCategory(int id);
    }   
}

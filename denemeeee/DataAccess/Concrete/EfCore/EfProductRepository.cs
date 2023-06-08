using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public class EfProductRepository :
     EfCoreGenericRepository<Product,DataContext>, IProductRepository
    {
        
        public int GetCountProductByCategory(int id)
        {
            using (var context=new DataContext())
            {
                var products = context.Products.AsQueryable();
                products = products.Where(i => i.CategoryId == id);

                return products.Count();
            }
                
               
            
        }

        public List<Product> GetProductsByCategory(int id, int page, int pageSize)
        {
            using (var context=new DataContext())
            {

                var products = context.Products.AsQueryable();
                products = products.Where(i => i.CategoryId == id);

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
             
        }

        public List<Product> GetSearchResult(string searchResult)
        {
            using (var context = new DataContext())
            {
                var products = context.Products
                                       .Where(i => i.Name.ToLower().Contains(searchResult.ToLower()))
                                    .AsQueryable();

                return products.ToList();
            }
            
                
            
        }
    }
}

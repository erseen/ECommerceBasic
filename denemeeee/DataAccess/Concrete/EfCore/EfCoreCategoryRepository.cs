using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryRepository : 
        EfCoreGenericRepository<Category,DataContext>, ICategoryRepository
    {
      

    }
}

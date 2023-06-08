using Entities;
using System.Collections.Generic;

namespace Uii.ViewModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
        public string CategoryName { get; set; }


    }
}

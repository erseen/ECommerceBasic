using Entities;
using System.Collections.Generic;

namespace Uii.ViewModels
{
    public class ProductDetailModel
    {

        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}

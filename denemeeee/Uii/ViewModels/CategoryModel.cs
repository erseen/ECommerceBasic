using Entities;
using System.Collections.Generic;

namespace Uii.ViewModels
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }

    }
}

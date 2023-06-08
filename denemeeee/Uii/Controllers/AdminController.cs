using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using Uii.ViewModels;

namespace Uii.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminController(IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;

        }
        public IActionResult ProductList()
        {
            var homeViewModel = new HomeViewModel()
            {
                Products = _productService.GetAll()
            };

            return View(homeViewModel);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var ProductModel = new ProductModel()
            {
                Categories = _categoryService.GetAll()
            };
            return View(ProductModel);
        }


        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,

            };
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün eklendi ",
                AlertType = "success"

            };
            _productService.create(entity);
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var entity = _productService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();

            }
            var productModel = new ProductModel()
            {
                ProductId = entity.ProductId,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                Name = entity.Name,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,


            };

            return View(productModel);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel productModel)
        {
            var entity = _productService.GetById(productModel.ProductId);

            if (entity == null)
            {
                return NotFound();

            }
            entity.Name = productModel.Name;
            entity.Price = productModel.Price;
            entity.ImageUrl = productModel.ImageUrl;
            entity.Description = productModel.Description;

            _productService.update(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün güncellendi ",
                AlertType = "success"

            };
          
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ProductList");

         }
        public IActionResult DeleteProduct(int productId)
        {
            var entity= _productService.GetById(productId);
            if (entity!=null)
            {

                _productService.delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün silindi ",
                AlertType = "danger"

            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }
        //Kategori Listesi
        public IActionResult CategoryList()
        {
            var categoryListModel = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            };

           return View(categoryListModel);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
           
            
            return View(); 
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name,
               

            };
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli category eklendi ",
                AlertType = "success"

            };
            _categoryService.create(entity);
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");

        }
        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var entity = _categoryService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();

            }
            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,

            };

            return View(model);



        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.CategoryId); 

            if (entity == null)
            {
                return NotFound();

            }
          
            entity.Name = model.Name; 
            _categoryService.update(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün güncellendi ",
                AlertType = "success"

            };



            return RedirectToAction("CategoryList");

        }
        public IActionResult DeleteCategory(int CategoryId)
        {

            var entity = _categoryService.GetById(CategoryId);
            if (entity != null)
            {

                _categoryService.delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli category silindi ",
                AlertType = "danger"

            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");

        }

    }
}

using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Uii.Models;
using Uii.ViewModels;

namespace Uii.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;  

        public HomeController(IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService; 


        }

        //Pagination işlemi sadece index sayfasına yapıldı 
        public IActionResult Index()
        {
           
                var homeViewModel = new HomeViewModel()
                {
                 Products = _productService.GetAll(),
                 Categories = _categoryService.GetAll()
               };

                return View(homeViewModel);
           
        }
        public IActionResult GetProductsWithCategory(int id, int page = 1)
        {
            const int pageSize = 3;

            var homeViewModel = new HomeViewModel()
            {

                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountProductByCategory(id),
                    CurrentPage =page, 
                    ItemsPerPage= pageSize,
        

                },

                Products = _productService.GetProductsByCategory(id,page,3),
                Categories = _categoryService.GetAll()
            };

            return View(homeViewModel);

        }
        public IActionResult Details(int id)
        {
            var detailsModel = new ProductDetailModel()
            {
                Product = _productService.GetById(id),
                Categories = _categoryService.GetAll()

            };


            return View(detailsModel);
        }
        public IActionResult Search(string q)
        {
            if (q==null)
            {
                return NotFound();
            }
            
            var homeViewModel = new HomeViewModel()
            {
                Products = _productService.GetSearchResult(q),
                Categories= _categoryService.GetAll()
            };

            return View(homeViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Uii.ViewModels
{

   public class PageInfo
    {
        public int TotalItems { get; set; }
        public int  ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
    public class HomeViewModel
    {
        public PageInfo  PageInfo { get; set; }
        public List <Category> Categories { get; set; }
        public List <Product>Products { get; set; }
    }
}

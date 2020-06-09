using Microsoft.AspNetCore.Mvc;
using Movie.Business.Abstract;
using Movie.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
       public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel() { 
            Categories = _categoryService.GetAll()
            });
        }
    }
}

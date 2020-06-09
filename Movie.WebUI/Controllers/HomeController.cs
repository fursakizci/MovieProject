using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Abstract;
using Movie.WebUI.Models;

namespace Movie.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMovieService _movieService;
        private ICategoryService _categoryService;
        public HomeController(IMovieService movieService,ICategoryService categoryService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(new MovieListModel()
            {
                Movies = _movieService.GetAll(),
                Categories = _categoryService.GetAll() 
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Abstract;
using Movie.Entity;
using Movie.WebUI.Models;

namespace Movie.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IMovieService _movieService;
        private ICategoryService _categoryService;
        public AdminController(IMovieService movieService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View(new MovieListModel()
            {
                Movies = _movieService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMovie(Movie.WebUI.Models.MovieModel model)
        {
            var entity = new Entity.Movie() 
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };

            _movieService.Create(entity);

            return RedirectToAction("Index");
        }
        public IActionResult EditMovie(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var entity = _movieService.GetById((int)id);

            if(entity == null)
            {
                return NotFound();
            }
            var model = new MovieModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditMovie(MovieModel model)
        {

            var entity = _movieService.GetById(model.Id);

            if(entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.ImageUrl = model.ImageUrl;
            entity.Description = model.Description;

            _movieService.Update(entity);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteMovie(int movieId)
        {
            var entity = _movieService.GetById(movieId);
            if(entity != null)
            {
                _movieService.Delete(entity);
            }

            return RedirectToAction("Index");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);
            
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult EditCategory(int Id)
        {
           
            var entity = _categoryService.GetById(Id);

            if(entity == null)
            {
                return NotFound();
            }

            return View(new CategoryModel() 
            {
            Id = entity.Id,
            Name = entity.Name
            });
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);

            if(entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if(entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }
    }
}
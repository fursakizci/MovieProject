﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            return View(new MovieModel());
        }
        [HttpPost]
        public IActionResult CreateMovie(Movie.WebUI.Models.MovieModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Entity.Movie()
                {
                    Name = model.Name,
                    Description = model.Description,
                    
                };

                if(file != null)
                {
                    entity.ImageUrl = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                }

                _movieService.Create(entity);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }
        public IActionResult EditMovie(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var entity = _movieService.GetByIdWithCategories((int)id);

            if(entity == null)
            {
                return NotFound();
            }
            var model = new MovieModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
                SelectedCategory = entity.MovieCategories.Select(i => i.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult EditMovie(MovieModel model, int[] categoryIds,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                var entity = _movieService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.Description = model.Description;

                if(file != null)
                {
                    entity.ImageUrl = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                _movieService.Update(entity, categoryIds);

                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
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
           
            var entity = _categoryService.GetByIdWithMovie(Id);

            if(entity == null)
            {
                return NotFound();
            }

            return View(new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Movies = entity.MovieCategories.Select(i => i.Movie).ToList()
            }) ;
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
        public IActionResult DeleteFromCategory(int movieId, int categoryId)
        {
            _categoryService.DeleteFromCategory(movieId, categoryId);

            return Redirect("/Admin/EditCategory/"+categoryId);
        }

       
    }
}
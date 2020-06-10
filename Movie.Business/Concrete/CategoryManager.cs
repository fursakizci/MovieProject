using Movie.Business.Abstract;
using Movie.DataAccess.Abstract;
using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public void DeleteFromCategory(int movieId, int categoryId)
        {
            _categoryDal.DeleteFromCategory(movieId, categoryId);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll().ToList();
        }

        public Category GetById(int Id)
        {
            return _categoryDal.GetById(Id);
        }
        public Category GetByIdWithMovie(int Id)
        {
            return _categoryDal.GetByIdWithMovie(Id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}

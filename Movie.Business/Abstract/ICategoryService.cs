using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int Id);
        Category GetByIdWithMovie(int Id);
        void DeleteFromCategory(int movieId, int categoryId);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}

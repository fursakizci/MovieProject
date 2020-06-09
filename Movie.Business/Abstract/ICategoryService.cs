using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int Id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}

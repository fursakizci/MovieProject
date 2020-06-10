using Microsoft.EntityFrameworkCore;
using Movie.DataAccess.Abstract;
using Movie.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Movie.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, MovieContext>, ICategoryDal
    {
        public void DeleteFromCategory(int movieId, int categoryId)
        {
            using (var context = new MovieContext())
            {
                var cmd = @"delete from MovieCategory where MovieId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlCommand(cmd, movieId, categoryId);
            }
        }

        public Category GetByIdWithMovie(int Id)
        {
            using (var context = new MovieContext()) 
            {
                return context.Categories
                    .Where(i => i.Id == Id)
                    .Include(i => i.MovieCategories)
                    .ThenInclude(i => i.Movie)
                    .FirstOrDefault();
            }
        }
      
    }

}

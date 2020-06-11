using Microsoft.EntityFrameworkCore;
using Movie.DataAccess.Abstract;
using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.DataAccess.Concrete.EfCore
{
    public class EfCoreMovieDal : EfCoreGenericRepository<Entity.Movie, MovieContext>, IMovieDal
    {
        public Entity.Movie GetByIdWithCategories(int Id)
        {
            using (var context = new MovieContext())
            {
                return context.Movies
                    .Where(i => i.Id == Id)
                    .Include(i => i.MovieCategories).
                    ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public void Update(Entity.Movie entity, int[] categoryIds)
        {
            using (var context = new MovieContext())
            {
                var product= context.Movies
                    .Include(i => i.MovieCategories)
                    .FirstOrDefault(i => i.Id == entity.Id);

                if(product != null)
                {
                    product.Name = entity.Name;
                    product.ImageUrl = entity.ImageUrl;
                    product.Description = entity.Description;

                    product.MovieCategories = categoryIds.Select(i => new MovieCategory()
                    {
                        CategoryId = i,
                        MovieId = entity.Id
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}

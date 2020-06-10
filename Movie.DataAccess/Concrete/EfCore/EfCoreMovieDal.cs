using Microsoft.EntityFrameworkCore;
using Movie.DataAccess.Abstract;
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
    }
}

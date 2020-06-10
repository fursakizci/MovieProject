using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.DataAccess.Abstract
{
    public interface IMovieDal:IRepository<Entity.Movie>
    {
        Entity.Movie GetByIdWithCategories(int Id);
    }
}

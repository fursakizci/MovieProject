using Movie.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.DataAccess.Concrete.EfCore
{
    public class EfCoreMovieDal:EfCoreGenericRepository<Entity.Movie,MovieContext>,IMovieDal
    {
    }
}

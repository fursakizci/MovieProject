using Movie.DataAccess.Abstract;
using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.DataAccess.Concrete.EfCore
{
    public class EfCoreFavoriteDal:EfCoreGenericRepository<Favorite,MovieContext>,IFavoriteDal
    {
    }
}

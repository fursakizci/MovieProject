using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Business.Abstract
{
    public interface IMovieService
    {
        Entity.Movie GetById(int Id);
        List<Entity.Movie> GetAll();
        void Create(Entity.Movie entity);
        void Update(Entity.Movie entity);
        void Delete(Entity.Movie entity);
      
    }
}

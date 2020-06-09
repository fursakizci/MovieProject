using Movie.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movie.DataAccess.Concrete.MemoryMovie
{
    public class MemoryMovieDal : IMovieDal
    {
        public void Create(Entity.Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entity.Movie entity)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Movie> GetAll(Expression<Func<Entity.Movie, bool>> filter = null)
        {
            var movies = new List<Entity.Movie>()
            {
                new Entity.Movie(){Id=1,Name = "Deneme1",ImageUrl = "1.jpg",Description="aciklama1"},
                new Entity.Movie(){Id=1,Name = "Deneme2",ImageUrl = "2.jpg",Description="aciklama2"}
            };
            return movies;
        }

        public Entity.Movie GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Entity.Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}

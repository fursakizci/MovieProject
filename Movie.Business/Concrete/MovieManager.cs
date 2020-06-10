using Movie.Business.Abstract;
using Movie.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieDal _movieDal;
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        public void Create(Entity.Movie entity)
        {
            _movieDal.Create(entity);
        }

        public void Delete(Entity.Movie entity)
        {
            _movieDal.Delete(entity);
        }

        public List<Entity.Movie> GetAll()
        {
            return _movieDal.GetAll().ToList();
        }

        public Entity.Movie GetById(int Id)
        {
            return _movieDal.GetById(Id);
        }

        public Entity.Movie GetByIdWithCategories(int Id)
        {
            return _movieDal.GetByIdWithCategories(Id);
        }

        public void Update(Entity.Movie entity)
        {
            _movieDal.Update(entity);
        }
    }
}

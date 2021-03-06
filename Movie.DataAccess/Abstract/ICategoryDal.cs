﻿using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.DataAccess.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {
        Category GetByIdWithMovie(int Id);
        void DeleteFromCategory(int movieId, int categoryId);
        

    }
}

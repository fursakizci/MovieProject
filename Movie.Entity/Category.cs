using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
    }
}

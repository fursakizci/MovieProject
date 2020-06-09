using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
    }
}

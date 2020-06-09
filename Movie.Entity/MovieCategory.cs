using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entity
{
    public class MovieCategory
    {
        public int MovieId { get; set; }
        public Entity.Movie Movie { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

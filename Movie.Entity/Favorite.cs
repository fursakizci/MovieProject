using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entity
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<Entity.Movie> Movies { get; set; }
    }
}

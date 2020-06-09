using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.WebUI.Models
{
    public class MovieListModel
    {
        public List<Entity.Movie> Movies { get; set; }
        public List<Category> Categories { get; set; }
    }
}

using Movie.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.WebUI.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30,ErrorMessage = "You can enter a maximum of 30 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(500,ErrorMessage ="You can enter a maximum of 500 caharacters.")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Category> SelectedCategory { get; set; }
    }
}

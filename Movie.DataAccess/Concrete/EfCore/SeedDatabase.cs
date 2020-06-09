using Microsoft.EntityFrameworkCore;
using Movie.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new MovieContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                    //AddRange ile birden fazla nesneyi database'e ekleme islemi
                }
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(Movies);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories =
        {
            new Category(){Name="dram"},
            new Category(){Name="korku"}
        };
        private static Entity.Movie[] Movies =
         {
            new Entity.Movie(){Name="deneme1",Description="aciklama1",ImageUrl="1.jpg"},
            new Entity.Movie(){Name="deneme2",Description="aciklama2",ImageUrl="2.jpg"},
            new Entity.Movie(){Name="deneme3",Description="aciklama3",ImageUrl="3.jpg"},
            new Entity.Movie(){Name="deneme4",Description="aciklama4",ImageUrl="4.jpg"}
        };

        private static MovieCategory[] MovieCategories =
        {
            new MovieCategory(){Movie = Movies[0],Category = Categories[0]},
            new MovieCategory(){Movie = Movies[1],Category = Categories[1]},
            new MovieCategory(){Movie = Movies[0],Category = Categories[2]},
            new MovieCategory(){Movie = Movies[1],Category = Categories[3]},
        };

    }
}

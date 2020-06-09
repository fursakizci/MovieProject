using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie.Business.Abstract;
using Movie.Business.Concrete;
using Movie.DataAccess.Abstract;
using Movie.DataAccess.Concrete.EfCore;
using Movie.DataAccess.Concrete.MemoryMovie;
using Movie.WebUI.MiddleWares;

namespace Movie.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews()
                   .AddRazorRuntimeCompilation();

            services.AddScoped<IMovieDal, EfCoreMovieDal>();
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<ICategoryService,CategoryManager>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"adminMovie",
                    template:"admin/movies",
                    defaults: new { controller = "Admin", action = "Index" } 
                    );

                routes.MapRoute(
                    name: "adminMovies",
                    template: "admin/movies/{id?}",
                    defaults: new { controller = "Admin", action = "EditMovie" }
                    );

                routes.MapRoute(
                   name: "adminCategorie",
                   template: "admin/categories",
                   defaults: new { controller = "Admin", action = "CategoryList" }
                   );

                routes.MapRoute(
                   name: "adminCategories",
                   template: "admin/categories/{id?}",
                   defaults: new { controller = "Admin", action = "EditCategory" }
                   );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}

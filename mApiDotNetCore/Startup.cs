using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Model.Entities;
using Newtonsoft.Json;
using Repository.Interfaces;
using Repository.Repositories;
using Service.interfaces;
using Service.Services;

namespace mApiDotNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MovieDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MovieDb")));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped(typeof(IServiceGeneric<>),typeof(ServiceGeneric<>));
            services.AddScoped(typeof(IRepositoryGeneric<>),typeof(RepositoryGeneric<>));
            services.AddScoped<IServiceGeneric<Movie>, MovieService>();
            services.AddMvc().AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

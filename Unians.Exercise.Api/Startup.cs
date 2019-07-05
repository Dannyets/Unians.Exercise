using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Infrastructure.Repositories.EntityFrameworkCore.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Unians.Exercise.Data.Context;
using Unians.Exercise.Data.Interfaces;
using Unians.Exercise.Data.Repositories;

namespace Unians.Exercise.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ExerciseDbContext>();

            services.AddTransient<DbContext, ExerciseDbContext>();

            services.AddTransient<IExerciseRepository, ExerciseRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                var info = new Info
                {
                    Title = "Exercise Web Api",
                    Version = "Vesrion 1",
                    Contact = new Contact
                    {
                        Name = "Danny Etsebban",
                        Email = "dannyets@gmail.com"
                    }
                };

                options.SwaggerDoc("v1", info);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //TODO: CHANGE TO MIGRATE ONCE DB IS CREATED
            DatabaseHelper.EnsureDatabaseCreated<ExerciseDbContext>(serviceProvider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise Web Api");
            });

            app.UseMvc();
        }
    }
}

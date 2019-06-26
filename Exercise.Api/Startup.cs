using System;
using AutoMapper;
using BaseRepositories.EntityFrameworkCore.MySql;
using De.Amazon.Configuration.Extensions;
using De.Amazon.Configuration.Models;
using Exercise.Api.Interfaces;
using Exercise.Api.Services;
using Exercise.DAL;
using Exercise.DAL.HealthChecks;
using Exercise.DAL.Interfaces;
using Exercise.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Exercise.Api
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

            var connectionString = "Server=unians-exercise-api.cwlhm9xdeq10.us-east-2.rds.amazonaws.com;Port=3306;Database=unians_exercise;Uid=root;Pwd=12345678;";

            Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", connectionString);

            services.AddDbContext<ExerciseDbContext>();

            services.AddTransient<IExerciseRepository, ExerciseRepository>();

            services.AddTransient<INotificationService, SimpleNotificationService>();

            services.AddAwsConfiguration();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHealthChecks()
                    .AddCheck<RepositoryHealthCheck>("Repository");

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
        public async void Configure(IApplicationBuilder app, 
                                    IHostingEnvironment env, 
                                    IServiceProvider serviceProvider)
        {
            MySqlDbHelper.MigrateDatabase<ExerciseDbContext>(serviceProvider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise Web Api");
            });

            app.UseMvc();
        }
    }
}

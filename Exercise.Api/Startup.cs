using System;
using Amazon;
using Amazon.Runtime;
using AutoMapper;
using Exercise.Api.Amazon;
using Exercise.Api.HealthChecks;
using Exercise.Api.Interfaces;
using Exercise.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddTransient<IExerciseRepository, ExerciseRepository>();

            services.AddTransient<IFileUploader, S3FileUploader>();

            ConfigureAws(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHealthChecks()
                    .AddCheck<RepositoryHealthCheck>("Repository");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseMvc();
        }

        public void ConfigureAws(IServiceCollection services)
        {
            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");

            var region = RegionEndpoint.USEast2;

            var credentials = new BasicAWSCredentials(accessKey, secretKey);

            var amazonConfig = new AmazonConfig(credentials, region);

            services.AddSingleton(amazonConfig);
        }
    }
}

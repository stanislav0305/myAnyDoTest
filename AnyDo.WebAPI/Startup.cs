using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AnyDo.Data.Repositories;
using Microsoft.AspNetCore.Routing;
using System.Reflection.Metadata;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using AnyDo.Data.Entities;

namespace AnyDo.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) //(IConfiguration configuration)
        {
            //Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AnyDoDbContext>(options => options.UseSqlServer(connection));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IPreferencesRepository, PreferencesRepository>();
            services.AddTransient<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ISubTaskRepository, SubTaskRepository>();
            services.AddTransient<IAttachmentRepository, AttachmentRepository>();
            services.AddTransient<IMailSender, MailSender>();

            services.AddMvc();
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));

            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<UserViewModel, User>();
            //});

            //var mapper = config.CreateMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(
               builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");
            app.UseMvc();
            //app.UseMvc(routes =>
            //{

            //    routes.MapRoute("errors", "Errors/Error/{errorCode}",
            //        defaults: new { controller = "Errors", action = "Error" });

            //    //routes.MapRoute("default", "Errors/Error/{errorCode}",
            //    //    defaults: new { controller = "Home", action = "Errors" });
            //    // Add other routes / defualt route below);

            //});
        }
    }
}

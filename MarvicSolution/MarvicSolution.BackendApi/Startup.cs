using FluentValidation.AspNetCore;
using MarvicSolution.BackendApi.Constants;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest;
using MarvicSolution.Services.System.Helpers;
using MarvicSolution.Services.System.Users.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi
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
            // If develop a SPA the brower will prevent request from different port | check "app.UseCors" bollow
            services.AddCors();
            services.AddDbContext<MarvicDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString(SystemConstant.MainConnectionString)));

            /// Declare DI
            /// AddTransient: Moi lan request la tao moi 1 object
            services.AddTransient<IProjectType_Service, ProjectType_Service>();
            services.AddTransient<IProject_Service, Project_Service>();
            //services.AddTransient<IUser_Service, User_Service>();
            //services.AddTransient<Jwt_Service, Jwt_Service>();


            services.AddScoped<Jwt_Service, Jwt_Service>();
            services.AddScoped<IUser_Service, User_Service>();


            /// Validator Fluent Api
            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.DisableDataAnnotationsValidation = true; // = RunDefaultMvcValidationAfterFluentValidationExecutes = false; 
                });

            services.AddControllersWithViews();

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Marvic Solution", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(option => option
            .WithOrigins(new[] { "https:localhost:3000", "https:localhost:8000", "https:localhost:4200" }) // FE's port
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); // send cookie to FE

            app.UseAuthorization();

            // Swagger Middleware
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Marvic Solution v1"));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using FluentValidation.AspNetCore;
using MarvicSolution.BackendApi.Constants;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest;
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
            services.AddDbContext<MarvicDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString(SystemConstant.MainConnectionString)));

            // Register for Identity
            services.AddIdentity<App_User, App_Role>()
                .AddEntityFrameworkStores<MarvicDbContext>()
                .AddDefaultTokenProviders();

            /// Declare DI
            /// AddTransient: Moi lan request la tao moi 1 object
            services.AddTransient<IProjectType_Service, ProjectType_Service>();
            services.AddTransient<IProject_Service, Project_Service>();

            services.AddTransient<RoleManager<App_Role>, RoleManager<App_Role>>();
            services.AddTransient<UserManager<App_User>, UserManager<App_User>>();
            services.AddTransient<SignInManager<App_User>, SignInManager<App_User>>();

            services.AddTransient<IUser_Service, User_Service>();


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

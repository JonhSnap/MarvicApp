using FluentValidation.AspNetCore;
using MarvicSolution.BackendApi.Constants;
using MarvicSolution.BackendApi.Hubs;
using MarvicSolution.DATA.EF;
using MarvicSolution.Services.Comment_Request.Services;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.Project_Resquest.Dtos.Validators;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest;
using MarvicSolution.Services.Sprint_Request.Services;
using MarvicSolution.Services.System.Helpers;
using MarvicSolution.Services.SendMail_Request.Dtos.Services;
using MarvicSolution.Services.SendMail_Request.Dtos.Settings;
using MarvicSolution.Services.System.Users.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MarvicSolution.Services.Label_Request.Services;
using MarvicSolution.Services.Stage_Request.Services;
using Microsoft.Extensions.Logging;
using System.IO;
using MarvicSolution.Services.Answer_Request.Services;

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
            services.AddSignalR();

            services.AddDbContext<MarvicDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString(SystemConstant.ConnectionString)));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            /// Declare DI
            /// AddTransient: Moi lan request la tao moi 1 object
            services.AddTransient<IProjectType_Service, ProjectType_Service>();
            services.AddTransient<IProject_Service, Project_Service>();
            services.AddScoped<IIssue_Service, Issue_Service>();
            services.AddTransient<ITest_Service, Test_Service>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<Jwt_Service, Jwt_Service>();
            services.AddScoped<IUser_Service, User_Service>();
            services.AddScoped<IComment_Service, Comment_Service>();
            services.AddScoped<ISprint_Service, Sprint_Service>();
            services.AddScoped<ILabel_Service, Label_Service>();
            services.AddScoped<IStage_Service, Stage_Service>();

            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Project_Create_Validate>(); // Su dung tat ca class Validator nam trong cung 1 assemblies
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile($"{env.WebRootPath}\\Logs\\Log.txt");
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
            .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8000", "http://localhost:4200" }) // FE's port
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

                endpoints.MapHub<ActionHub>("/hubs/marvic");
            });
        }
    }
}

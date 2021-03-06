using BLL.Factories;
using BLL.Interfaces;
using BLL.Services;
using DAL.DatabaseContext;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EDiary
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        // Notice we are using Dependency Injection here
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<EDiaryDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("EDiaryDBConnection")));
            services.AddMvc();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<EDiaryDbContext>();
            services.AddScoped<IToDoModelFactory, ToDoModelFactory>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<ICalendarModelFactory, CalendarModelFactory>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<ITaskModelFactory, TaskModelFactory>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IFileModelFactory, FileModelFactory>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISubjectModelFactory, SubjectModelFactory>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GASF.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GASF.EFDataAccess;
using GASF.ApplicationLogic.Services;
using GASF.ApplicationLogic.Abstractions;
using GASF.EFDataAccess.Migrations;

namespace GASF
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            
            //services.AddDbContext<StudentRecordDbContext>(options => 
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<TeacherService>();
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();\
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ITeachersService, TeachersService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<ISecretaryService, SecretaryService>();
            services.AddScoped<ISecretaryRepository, SecretaryRepository>();

            services.AddScoped<ICertificateForSudentsRepository, CertificateForStudentsRepository>();
            services.AddScoped<ICertificatesForStudentsService, CertificateForStudentsService> ();

            services.AddScoped<ICertificateForTeachersRepository, CertificateForTeachersRepository>();
            services.AddScoped<ICertificateForTeachersService, CertificateForTeachersService>();
            //services.AddTransient(typeof(StudentsService), typeof(StudentsService));

            var connection = @"Server=(localdb)\mssqllocaldb;Database=aspnet-GASF-C6AB9B42-F869-4F54-BA59-D44D2514F390;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<StudentRecordDbContext>
                (options => options.UseSqlServer(connection));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<StudentRecordDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

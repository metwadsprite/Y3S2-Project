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
using GASF.Areas.Identity.Auth;
using Microsoft.AspNetCore.Authorization;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<StudentRecordDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
          
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<StudentService>();
           
            services.AddScoped<IExamRepository, ExamRepository>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<CourseService>();

            services.AddScoped<TeacherService>();

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

            services.AddScoped<UserService>();

            services.AddTransient<IAuthorizationHandler, UserHandler>();
            services.AddAuthorization(options => 
            {
                options.AddPolicy("Secretary",
                    policy => policy.Requirements.Add(new UserRequirement("Secretary"))
                );
                options.AddPolicy("Student",
                    policy => policy.Requirements.Add(new UserRequirement("Student"))
                );
                options.AddPolicy("Teacher",
                    policy => policy.Requirements.Add(new UserRequirement("Teacher"))
                );
            });
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

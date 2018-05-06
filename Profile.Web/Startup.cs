using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profile.DataAccess.Data;
using Profile.Web.Filters;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Profile.Model.Models;
using Profile.Web.Middleware;
using Profile.Service.Services.Interfaces;
using Profile.Service.Services;

namespace Profile.Web
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
            services.AddSession();
            services.AddDbContext<ProfileDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ProfileDbContext>()
                .AddDefaultTokenProviders();

            // Add Database Initializer
            //services.AddScoped<IDbInitializer, DbInitializer>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<AddUserToViewDataFilter>();

            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IResumeService, ResumeService>();
            services.AddTransient<IStreamService, StreamService>();
            services.AddTransient<ISummaryService, SummaryService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IForeignLanguageService, ForeignLanguageService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICertificateService, CertificateService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IWorkExperienceService, WorkExperienceService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IMilitaryStatusService, MilitaryStatusService>();
            services.AddTransient<IRecommendationService, RecommendationService>();
            services.AddTransient<IAdditionalInfoService, AdditionalInfoService>();
            services.AddTransient<IDateService, DateService>();
            services.AddTransient<ITrainerService, TrainerService>();
            services.AddTransient<IHrManagerService, HrManagerService>();

            #region wrapper services
            services.AddTransient<IEditResumeService, EditResumeService>();
            services.AddTransient<IUserInfoResumeService, UserInfoResumeService>();
            services.AddTransient<IStreamResumeService, StreamResumeService>();
            services.AddTransient<ISummaryResumeService, SummaryResumeService>();
            services.AddTransient<ISkillResumeService, SkillResumeService>();
            services.AddTransient<IForeingLanguageResumeService, ForeignLanguageResumeService>();
            services.AddTransient<IEducationResumeService, EducationResumeService>();
            services.AddTransient<ICourseResumeService, CourseResumeService>();
            services.AddTransient<ICertificateExamService, CertificateExamService>();
            services.AddTransient<ICertificateExamResumeService, CertificateExamResumeService>();
            services.AddTransient<IWorkExperienceResumeService, WorkExperienceResumeService>();
            services.AddTransient<IPortfolioResumeService, PortfolioResumeService>();
            services.AddTransient<IMilitaryStatusResumeService, MilitaryStatusResumeService>();
            services.AddTransient<IAdditionalInfoResumeService, AdditionalInfoResumeService>();
            services.AddTransient<IRecommendationResumeService, RecommendationResumeService>();
            #endregion


            var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();

            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(typeof(AddUserToViewDataFilter));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseContextAsUnitOfWork<ProfileDbContext>();

            app.UseSession();
            app.UseStaticFiles();

            app.UseAuthentication();

            //Generate EF Core Seed Data
            //dbInitializer.Initialize().Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

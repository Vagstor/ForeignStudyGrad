using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using DbMigrator;
using DataModels;
using ForeignStudyGrad.Services;

namespace ForeignStudyGrad
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
            services.AddRazorPages();
            LinqToDB.Data.DataConnection.DefaultSettings = new MySettings
            {
                //ConnString = Configuration.GetConnectionString("DefaultConnection")
                ConnString = 
                "Server=tcp:foreignstudygraddbserver.database.windows.net,1433;Initial Catalog=foreignstudy;Persist Security Info=False;User ID=fs;Password=Foreignstudy123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            };

            services.AddScoped<ForeignstudyDB>();
            services.AddScoped<AccountService>();
            services.AddScoped<CourseService>();
            //services.AddScoped<HttpService>();
            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddSingleton<MonitoringService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Welcome/Login");
                    options.AccessDeniedPath = new PathString("/Welcome/Login");
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
                app.UseExceptionHandler("/Welcome/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            MigrationRunner migrationRunner = new MigrationRunner();

            //вставить под connStr строку подключени€ дл€ миграции
            //var connStr = "Server=tcp:foreignstudygraddbserver.database.windows.net,1433;Initial Catalog=foreignstudy;Persist Security Info=False;User ID=fs;Password=Foreignstudy123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //migrationRunner.MigrationConnection(connStr);

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Welcome}/{action=Login}/{id?}");
            });
        }
    }
}

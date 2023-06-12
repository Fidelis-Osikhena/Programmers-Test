namespace Programmers_Test
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Programmers_Test.Data;
    using Microsoft.AspNetCore.Localization;
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.Options;

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
            // Configure Entity Framework with SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True;")));

            services.AddLocalization(o => { o.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en", "fr" };
                options.SetDefaultCulture(supportedCultures[0]);
                options.AddSupportedCultures(supportedCultures);
                options.AddSupportedUICultures(supportedCultures);
                //options.FallBackToParentUICultures = true;
                //options.RequestCultureProviders.Clear();

                options.RequestCultureProviders = new List<IRequestCultureProvider> 
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
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
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Tickets}/{action=Create}/{id?}");
            });
        }
    }

}

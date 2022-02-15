using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyRSVP.Models;

namespace PartyRSVP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<MyContext>(
                options => options.UseSqlServer(connectionString)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseEndpoints(services =>
            {
                services.MapControllerRoute("default", "{controller=CustomerRespond}/{action=Index}");
            });

        }
    }
}


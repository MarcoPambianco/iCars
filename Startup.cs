using iCars.Models.Applications;
using iCars.Models.Infrastructure;
using iCars.Models.Interfaces;
using iCars.Models.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace iCars
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
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });
            services.AddControllersWithViews();

            services.AddMemoryCache();
            

            services.AddTransient<ICachedParcoService, MemoryCacheParcoService>();
            services.AddTransient<IParcoService, AdoNetParcoService>();
            services.AddTransient<IDbParcoAccessor, SqlClientService>();

            // options
            services.Configure<DatabaseOptions>(Configuration.GetSection("Database"));
            services.Configure<MemoryCacheOptions>(Configuration.GetSection("MemoryCache"));
            services.Configure<MyMemoryCacheOptions>(Configuration.GetSection("MyMemoryCache"));


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
            app.UseMvc(builder => {
                builder.MapRoute("default", "{controller=Home}/{action=Index}/{strTarga?}");
            });
            
        }
    }
}


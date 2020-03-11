using Core.AppServices;
using Core.AppServices.Impl;
using Core.DomainServices;
using Data.Impl;
using LenesKlinik.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UrlShortener
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
            // ADD CORS
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // USE SQLITE DB
            services.AddDbContext<DataContext>(
                opt => opt.UseSqlite("Data Source=ShortUrl.db"));

            services.AddScoped<IUrlShorteningService, UrlShorteningService>();
            services.AddScoped<IShorteningRepo, ShorteningRepo>();

            // ADD CONTROLLERS
            // Set to reply with the data type requested by the browser.
            services.AddControllers(opts => {
                opts.RespectBrowserAcceptHeader = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("AllowAll");
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<DataContext>();
                //ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

        }
    }
}

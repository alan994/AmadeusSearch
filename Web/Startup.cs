using Dao;
using Dto.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.Services;
using Web.Services.Amadeus;

namespace Web
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

            services.AddDbContext<AmadeusContext>(
               options => options.UseSqlServer(
                   this.Configuration["Data:cs"],
                   sqlServerOptions => sqlServerOptions.MigrationsAssembly("Dao")));

            AutoMapperInitializer.Initialize();

            services.AddCors();
            services.AddTransient<CatalogService>();
            services.AddTransient<IFlightApi, AmadeusApi>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AmadeusContext db, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.Migrate();

            app.UseCors(cfg => cfg.WithOrigins(this.Configuration["Urls.client"])
                                     .AllowAnyOrigin()
                                     .AllowCredentials()
                                     .AllowAnyHeader()
                                     .AllowAnyMethod()
            );

            app.UseMvc();
        }
    }
}

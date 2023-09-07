using Microsoft.EntityFrameworkCore;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Infrastructure.ExtensionMethods;

namespace ProesBack
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
            services.AddRepositories().AddServices();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ProesContext>(c =>
                c.UseInMemoryDatabase("Proes"));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/api", api =>
            {
                api.UseRouting();
                api.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            });
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}

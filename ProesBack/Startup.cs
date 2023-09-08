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
            services.AddControllers();
            services.AddRepositories().AddServices();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ProesContext>(c =>
                c.UseInMemoryDatabase("Proes"));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Infrastructure.ExtensionMethods;
using System.Security.Claims;
using System.Text;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.GetKey());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience=false,
                    ValidateLifetime = true,
                    RoleClaimType = ClaimTypes.Role

                };
            });

            services.AddRepositories().AddServices();

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ProesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Proes"),
                actions => { actions.EnableRetryOnFailure(); });
            }, ServiceLifetime.Transient);
            
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c=>
            {
                c.EnableAnnotations();
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("AllowAllOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

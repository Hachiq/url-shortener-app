using Api.Data;
using Api.Mappers;
using Api.Repositories.UrlRepository;
using Api.Repositories.UserRepository;
using Api.Services.AuthService;
using Api.Services.UrlService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appConnectionString = builder.Configuration.
                GetConnectionString("AppDbContextConnection")
                ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(appConnectionString));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IAuthService, AuthService>();

            builder.Services.AddScoped<IUrlRepository, UrlRepository>();
            builder.Services.AddTransient<IUrlService, UrlService>();

            builder.Services.AddTransient<UrlMapper>();

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                    }
                ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors("NgOrigins");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
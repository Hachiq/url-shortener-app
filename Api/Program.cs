using Api.Data;
using Api.Repositories.UserRepository;
using Api.Services.AuthService;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
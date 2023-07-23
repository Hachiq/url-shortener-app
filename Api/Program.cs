using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Api.Areas.Identity.Data;
using Api.Data;
using Api.Services.AboutService;
using Api.Services.UrlService;

var builder = WebApplication.CreateBuilder(args);

var identityConnectionString = builder.Configuration.
    GetConnectionString("AppIdentityDbContextConnection") 
    ?? throw new InvalidOperationException("Connection string 'AppIdentityDbContextConnection' not found.");
var appConnectionString = builder.Configuration.
    GetConnectionString("AppDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(identityConnectionString));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(appConnectionString));

builder.Services.AddDefaultIdentity<AppIdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.User.AllowedUserNameCharacters = builder.Configuration.GetSection("AllowedUsernameCharacters").Value;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IUrlService, UrlService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

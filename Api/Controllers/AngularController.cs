using Api.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Api.Controllers;

public class AngularController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppIdentityUser> _userManager;

    public AngularController(IConfiguration configuration, UserManager<AppIdentityUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }
    public ActionResult Index()
    {
        string token = CreateToken();
        var redirectUrl = "http://localhost:4200/table?token=" + token;
        return Redirect(redirectUrl);
    }
    private string CreateToken()
    {
        var username = _userManager.GetUserName(User);
        if (string.IsNullOrEmpty(username))
        {
            // Handle the case when the user is not authenticated or username is not available.
            return string.Empty;
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, User.IsInRole("Admin") ? "Admin" : "User")
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}

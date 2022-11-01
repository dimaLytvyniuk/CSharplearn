using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace OpenIdStudy.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IdentityDbContext _dbContext;

    public IdentityController(IdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogInAsync([FromBody] UserSignInModel signInModel)
    {
        var user = await GetUserAsync(signInModel);
        if (user is null)
        {
            return BadRequest();
        }

        var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Surname, user.Surname),
        new Claim(ClaimTypes.Role, "Admin")
    };

        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return NoContent();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] UserSignUpModel signUpModel)
    {
        var user = new User(signUpModel.Name, signUpModel.Surname, signUpModel.Email, signUpModel.Password);

        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return Created(string.Empty, null);
    }

    private Task<User?> GetUserAsync(UserSignInModel signInModel)
    {
        return _dbContext
           .Users
           .FirstOrDefaultAsync(x => x.Email == signInModel.Email && x.Password == signInModel.Password);
    }
}

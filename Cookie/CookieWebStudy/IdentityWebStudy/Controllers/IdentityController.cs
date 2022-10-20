using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public IdentityController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUpAsync([FromBody] UserSignUpModel signUpModel)
    {
        var user = new User
        {
            Name = signUpModel.Name,
            Surname = signUpModel.Surname,
            Email = signUpModel.Email,
            UserName = signUpModel.Email
        };

        var userCreateResult = await _userManager.CreateAsync(user, signUpModel.Password);

        if (userCreateResult.Succeeded)
        {
            var roleAttachResult = await _userManager.AddToRoleAsync(user, "Admin");

            if (roleAttachResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            await _userManager.DeleteAsync(user);
            return Problem(roleAttachResult.Errors.First().Description, null, 500);
        }

        return Problem(userCreateResult.Errors.First().Description, null, 500);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(UserSignInModel signInModel)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == signInModel.Email);
        if (user is null)
        {
            return NotFound("User not found");
        }

        var userSigninResult = await _userManager.CheckPasswordAsync(user, signInModel.Password);

        if (userSigninResult)
        {
            return Ok();
        }

        return BadRequest("Email or password incorrect.");
    }
}
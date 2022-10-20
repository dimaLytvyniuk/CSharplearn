using Microsoft.AspNetCore.Identity;

namespace IdentityWebStudy;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }

    public string Surname { get; set; }
}

public record class UserSignInModel(string Email, string Password);

public record class UserSignUpModel(
    string Email,
    string Password,
    string Name,
    string Surname);
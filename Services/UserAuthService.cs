using Fribergs_Alpha.Components.Pages;
using Fribergs_Alpha.Data;
using Fribergs_Alpha.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Fribergs_Alpha.Services
{
    public class UserAuthService
    {
        private readonly IUserRepository _userRepo;

        public UserAuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // Primary user authentication function. Takes in user login credentials (email, password) and searches for
        // matching user and password in user- and adminrepositories.
        // If match is made, creates a claims profile/list of claims that is forwarded to Login.razor and tied to
        // the users authentication cookie.
        public AuthResult UserLogin(LoginCredentials credentials)
        {
            var result = new AuthResult();
            var claims = new List<Claim>();

            var user = _userRepo.GetUserByEmail(credentials.Email);
            if (user != null && user.Password == credentials.Password)
            {
                result.AuthSuccess = true;

                if (user.AdminRole)
                {
                    claims.Add(new Claim(type: ClaimTypes.Authentication, "Passed"));
                    claims.Add(new Claim(type: ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim(type: ClaimTypes.Name, $"ADMIN {user.FirstName} {user.LastName}"));
                    claims.Add(new Claim(type: ClaimTypes.UserData, user.UserId.ToString()));
                    result.RedirectPath = "/admin";
                }
                else
                {
                    claims.Add(new Claim(type: ClaimTypes.Authentication, "Passed"));
                    claims.Add(new Claim(type: ClaimTypes.Role, "Customer"));
                    claims.Add(new Claim(type: ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
                    claims.Add(new Claim(type: ClaimTypes.UserData, user.UserId.ToString()));
                    result.RedirectPath = "/customer";
                }
            }
            else
            {
                result.AuthSuccess = false;
                result.ErrorMessage = "Login credentials incorrect";
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            result.IdentityClaims = new ClaimsPrincipal(identity);

            return result;
        }
    }
}


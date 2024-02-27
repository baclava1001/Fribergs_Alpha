using System.Security.Claims;

namespace Fribergs_Alpha.Models
{
    public class AuthResult
    {
        public bool AuthSuccess { get; set; }
        public string RedirectPath { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public ClaimsPrincipal IdentityClaims { get; set; } = default!;
    }
}

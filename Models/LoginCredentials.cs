using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fribergs_Alpha.Models
{
    public class LoginCredentials
    {
        [EmailAddress(ErrorMessage = "Please enter a valid email adress")]
        [MaxLength(50)]
        public string Email { get; set; } = default!;

        [PasswordPropertyText]
        [MinLength(6, ErrorMessage = "Password must contain atleast 6 characters")]
        [MaxLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        public string Password { get; set; } = default!;
    }
}

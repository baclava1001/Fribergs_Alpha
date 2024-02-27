using Fribergs_Alpha.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Fribergs_Alpha.Services
{
    public class AuthenticationService
    {
        private readonly CustomerRepository _customerRepo;
        private readonly AdminRepository _adminRepo;



        public AuthenticationService(CustomerRepository customerRepo, AdminRepository adminRepo)
        {
            _customerRepo = customerRepo;
            _adminRepo = adminRepo;
        }


        public ClaimsPrincipal UserLogin(string email, string password)
        {
            var result = new LoginResult();
            var claims = new List<Claim>();
            var userIdentity = new ClaimsPrincipal();

            var customer = _customerRepo.GetCustomerByEmail(email);
            if (customer != null && customer.Password == password)
            {
                claims.Add(new Claim(type: ClaimTypes.Role, "Customer"));
                claims.Add(new Claim(type: ClaimTypes.UserData, customer.CustomerId.ToString()));

                result.RedirectPath = "/customer";
            }
            else if (customer == null)
            {
                var admin = _adminRepo.GetAdminByEmail(email);
                if (admin != null && admin.Password == password)
                {
                    claims.Add(new Claim(type: ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim(type: ClaimTypes.UserData, admin.AdminId.ToString()));

                    result.RedirectPath = "/admin";
                }
            }
            else
            {
                result.ErrorMessage = "Login credentials incorrect";
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            userIdentity = new ClaimsPrincipal(identity);

            return userIdentity;
        }

        public ClaimsPrincipal UserLogout()
        {
            //AuthenticationHttpContextExtensions.SignOutAsync

            //return 
        }




        public class LoginResult
        {
            public bool LoginSuccess { get; set; }
            public string RedirectPath { get; set; } = string.Empty;
            public string ErrorMessage { get; set; } = string.Empty;

        }
    }

}


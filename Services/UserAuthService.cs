﻿using Fribergs_Alpha.Data;
using Fribergs_Alpha.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Fribergs_Alpha.Services
{
    public class UserAuthService
    {
        private readonly ICustomer _customerRepo;
        private readonly IAdmin _adminRepo;

        public UserAuthService(ICustomer customerRepo, IAdmin adminRepo)
        {
            _customerRepo = customerRepo;
            _adminRepo = adminRepo;
        }

        // Primary user authentication function. Takes in user login credentials (email, password) and searches for
        // matching user and password in customer- and adminrepositories.
        // If match is made, creates a claims profile/list of claims that is forwarded to Login.razor and tied to
        // the users authentication cookie.
        public AuthResult UserLogin(LoginCredentials credentials)
        {
            var result = new AuthResult();
            var claims = new List<Claim>();

            var customer = _customerRepo.GetCustomerByEmail(credentials.Email);
            if (customer != null && customer.Password == credentials.Password)
            {
                claims.Add(new Claim(type: ClaimTypes.Authentication, "Passed"));
                claims.Add(new Claim(type: ClaimTypes.Role, "Customer"));
                claims.Add(new Claim(type: ClaimTypes.Name, $"{customer.FirstName} {customer.LastName}"));
                claims.Add(new Claim(type: ClaimTypes.UserData, customer.CustomerId.ToString()));

                result.AuthSuccess = true;
                result.RedirectPath = "/customer";
            }
            else if (customer == null)
            {
                var admin = _adminRepo.GetAdminByEmail(credentials.Email);
                if (admin != null && admin.Password == credentials.Password)
                {
                    claims.Add(new Claim(type: ClaimTypes.Authentication, "Passed"));
                    claims.Add(new Claim(type: ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim(type: ClaimTypes.Name, $"ADMIN {admin.FirstName} {admin.LastName}"));
                    claims.Add(new Claim(type: ClaimTypes.UserData, admin.AdminId.ToString()));

                    result.AuthSuccess = true;
                    result.RedirectPath = "/admin";
                }
                else
                {
                    result.AuthSuccess = false;
                    result.ErrorMessage = "Login credentials incorrect";
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


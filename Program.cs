using Fribergs_Alpha.Components;
using Fribergs_Alpha.Data;
using Fribergs_Alpha.Models;
using Fribergs_Alpha.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Fribergs_Alpha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnectionString") ?? throw new InvalidOperationException("Connection string 'ApplicationConnectionString' not found.")));

            builder.Services.AddQuickGridEntityFrameworkAdapter();
            builder.Services.AddTransient<IBooking, BookingRepository>();
            builder.Services.AddTransient<ICustomer, CustomerRepository>();
            builder.Services.AddTransient<IAdmin, AdminRepository>();
            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<ICarCategory, CarCategoryRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();

            var a1 = new Admin() { FirstName = "Hacker", LastName = "Man", Address = "CyberSpace", Email = "Hackerman@gmail.com", Password = "ezpz123", PhoneNumber = "234" };
            var cc1 = new CarCategory() { Category = "Snabb bil" };
            var cc2 = new CarCategory() { Category = "Långsam bil" };
            var cu1 = new Customer() { FirstName = "Customer", LastName = "Customer", Address = "Customercity", Email = "Customer@customer.com", Password = "customer123", PhoneNumber = "123" };
            var dbCtx = new ApplicationDbContext();
            dbCtx.Add(a1);
            dbCtx.Add(cc1);
            dbCtx.Add(cc2);
            dbCtx.Add(cu1);
            dbCtx.SaveChanges();

            // Cookie-based authentication.
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
            })
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    options.SlidingExpiration = true;
                });

            // Authorization policies with role claims.
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRoleRequired", policy => policy.RequireRole("Admin").RequireAuthenticatedUser());
                options.AddPolicy("CustomerRoleRequired", policy => policy.RequireRole("Customer").RequireAuthenticatedUser());
            });

            // Provide authentication to all component render modes.
            builder.Services.AddCascadingAuthenticationState();

            // Login authentication service that takes in user credentials and returns identityclaims.
            builder.Services.AddScoped<UserAuthService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

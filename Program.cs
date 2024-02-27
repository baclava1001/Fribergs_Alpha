using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Fribergs_Alpha.Components;
using Fribergs_Alpha.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


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
            builder.Services.AddTransient<IBooking, BookingRepository>();
            builder.Services.AddTransient<ICustomer, CustomerRepository>();
            builder.Services.AddTransient<IAdmin, AdminRepository>();
            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<ICarCategory, CarCategoryRepository>();

            // Cookie-based authentication.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/login";
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    x.SlidingExpiration = true;
                });

            // Login authentication service that takes in user credentials and returns identityclaims.
            builder.Services.AddScoped<AuthenticationService>();

            // Authorization policies with role claims.
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRoleRequired", policy => policy.RequireRole("Admin"));
                options.AddPolicy("CustomerRoleRequired", policy => policy.RequireRole("Customer"));
            });

            // Provide authentication to all render render modes.
            builder.Services.AddCascadingAuthenticationState();

          
            

            builder.Services
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

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

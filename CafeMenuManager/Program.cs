using Microsoft.AspNetCore.Identity;
using CafeMenuManager.DAL;
using CafeMenuManager.BLL;
using Microsoft.EntityFrameworkCore;
namespace CafeMenuManager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CafeMenuContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CafeMenuContext>();
            builder.Services.AddScoped<MenuItemService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<IngredientService>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }

                var adminEmail = "admin@cafemanager.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Admin123!");
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }

                var userEmail = "user@cafemanager.com";
                var standardUser = await userManager.FindByEmailAsync(userEmail);

                if (standardUser == null)
                {
                    standardUser = new IdentityUser
                    {
                        UserName = userEmail,
                        Email = userEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(standardUser, "User123!");
                    await userManager.AddToRoleAsync(standardUser, "User");
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

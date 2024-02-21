namespace BeeSoft.Web.Infrastructure.Extensions;

using System;
using System.Linq;
using System.Threading.Tasks;

using BeeSoft.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using static BeeSoft.Common.GlobalConstants;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var services = serviceScope.ServiceProvider;

        var dbContext = services.GetRequiredService<BeeSoftDbContext>();
        dbContext.Database.Migrate();

        SeedRoles(services);
        SeedAdministrator(services);

        return app;
    }

    private static void SeedRoles(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        if (roleManager.Roles.Any())
        {
            return;
        }

        Task
            .Run(async () =>
            {
                await roleManager.CreateAsync(new IdentityRole(AdministratorRoleName));
            })
            .GetAwaiter()
            .GetResult();
    }

    private static void SeedAdministrator(IServiceProvider services)
    {
        const string adminUsername = "admin";
        const string adminEmail = "admin@bs.com";
        const string adminPassword = "adminBs24";

        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        if (userManager.Users.Any(u => u.UserName == adminUsername))
        {
            return;
        }

        Task
            .Run(async () =>
            {
                var role = await roleManager.FindByNameAsync(AdministratorRoleName);

                var user = new IdentityUser
                {
                    UserName = adminUsername,
                    Email = adminEmail,
                };

                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, role!.Name!);
            })
            .GetAwaiter()
            .GetResult();
    }
}

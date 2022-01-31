namespace CameraBazaar.Web.Infrastructure.Extentions
{
    using Data;
    using Constants;
    using Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CameraBazaarDbContext>().Database.Migrate();


                //var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                //var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                //Task
                //    .Run(async () =>
                //    {
                //        var adminName = GlobalConstants.AdministratorRole;
                //        var roleExists = await roleManager.RoleExistsAsync(adminName);

                //        if (!roleExists)
                //        {
                //            await roleManager.CreateAsync(new IdentityRole
                //            {
                //                Name = adminName
                //            });
                //        }

                //        var adminEmail = "boyan_f@abv.bg";
                //        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                //        if (adminUser == null)
                //        {
                //            adminUser = new User
                //            {
                //                Email = adminEmail,
                //                UserName = adminEmail
                //            };

                //            await userManager.CreateAsync(adminUser, "Boyan16091979");
                //            await userManager.AddToRoleAsync(adminUser, adminName);
                //        }
                //    })
                //    .Wait();
            }
            return app;
        }
    }
}

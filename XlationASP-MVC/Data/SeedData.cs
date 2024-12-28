//using Microsoft.AspNetCore.Identity;
//using XlationASP.Models;

//namespace XlationASP.Data
//{
//    public class SeedData
//    {
//        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
//        {
//            string[] roleNames = RoleName.Roles;
//            IdentityResult roleResult;

//            foreach (var roleName in roleNames)
//            {
//                var roleExist = await roleManager.RoleExistsAsync(roleName);
//                if (!roleExist)
//                {
//                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
//                }
//            }

//            var adminUser = new ApplicationUser
//            {
//                UserName = "xlationAdmin",
//                Email = "admin@xlation.com",
//                EmailConfirmed = true
//            };

//            var testUserPw = "Xlation@202412";

//            var user = await userManager.FindByEmailAsync(adminUser.Email);

//            if (user == null)
//            {
//                var createAdminUser = await userManager.CreateAsync(adminUser, testUserPw);
//                if (createAdminUser.Succeeded)
//                {
//                    await userManager.AddToRoleAsync(adminUser, RoleName.Admin);
//                }
//            }
//        }
//    }
//}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XlationASP.Models;

namespace XlationASP.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>

                // The admin user can do anything
                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@xlation.com");
                await EnsureRole(serviceProvider, adminID, RoleName.Admin);

                // The xlator user can see data
                var xlatorID = await EnsureUser(serviceProvider, testUserPw, "xlator@xlation.com");
                await EnsureRole(serviceProvider, xlatorID, RoleName.Xlator);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}
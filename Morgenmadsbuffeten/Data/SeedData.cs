using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Morgenmadsbuffeten.Data
{
    public class SeedData
    {

        //public static void SeedUsers(UserManager<ApplicationUser> userManager, ILogger log)
        //{
        //    const string adminEmail = "Admin@localhost";
        //    const string adminPassword = "Secret7/";

        //    if (userManager.FindByNameAsync(adminEmail).Result == null)
        //    {
        //        log.LogWarning("Seeding the admin user");
        //        var user = new ApplicationUser
        //        {
        //            UserName = adminEmail,
        //            Email = adminEmail,
        //            Name = "Admin"
        //        };
        //        IdentityResult result = userManager.CreateAsync
        //            (user, adminPassword).Result;
        //        if (result.Succeeded)
        //        {
        //            var adminClaim = new Claim("Admin", "Yes");
        //            userManager.AddClaimAsync(user, adminClaim);
        //        }
        //    }
        }
    }
}

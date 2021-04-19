using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Data
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, ILogger log)
        {
            List<IdentityUser> Users = new List<IdentityUser>();
            //Kitchen
            IdentityUser kitchenUser = new IdentityUser();
            kitchenUser.Email = "kitchen@breakfeastclub.com";
            kitchenUser.UserName = kitchenUser.Email;
            //Reception
            IdentityUser receptionUser = new IdentityUser();
            receptionUser.Email = "reception@breakfeastclub.com";
            receptionUser.UserName = receptionUser.Email;
            //Waiter
            IdentityUser waiterUser = new IdentityUser();
            waiterUser.Email = "waiter@breakfeastclub.com";
            waiterUser.UserName = waiterUser.Email;

            Users.Add(kitchenUser);
            Users.Add(receptionUser);
            Users.Add(waiterUser);

            string[] userRoles = new[] {"Kitchen", "Reception", "Waiter"};

            //Passwords
            const string kitchenPassword = "food4life";
            const string receptionPassword = "ripreception4life";
            const string waiterPassword = "waiting4life";

            string[] passwords = new[] {kitchenPassword, receptionPassword, waiterPassword };
            int counter = 0;

            foreach (var applicationUser in Users)
            {
                if (userManager.FindByNameAsync(applicationUser.Email).Result == null)
                {
                    log.LogWarning($"Seeding the {userRoles[counter]} user");

                    IdentityResult result = userManager.CreateAsync(applicationUser, passwords[counter]).Result;

                    if (result.Succeeded)
                    {
                        var roleClaim = new Claim("Role", userRoles[counter]);
                        userManager.AddClaimAsync(applicationUser, roleClaim);
                    }
                }

                counter++;
            }
        }
    }
}

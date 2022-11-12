using Microsoft.AspNetCore.Identity;
using ShoppingCard.Models.Entities;
using ShoppingCard.Utility.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Utility.Services {
    public class DbInitlizar : IDbInitlizar {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public DbInitlizar(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
 
            _roleManager = roleManager;
        }
        public async void Initlizar()
        {
               if(! ((await _roleManager.RoleExistsAsync(Website.Role_admin)) ||( _roleManager.Roles.Any())))
                {
                await _roleManager.CreateAsync(new IdentityRole() { Name = Website.Role_admin });
                await _roleManager.CreateAsync(new IdentityRole() { Name = Website.Role_customer});
                await _roleManager.CreateAsync(new IdentityRole() { Name = Website.Role_Employee });
               }
            await _userManager.CreateAsync(new ApplicationUser() { 
               UserName="admin@gamil.com",
               Email="admin@gamil.com",
                PhoneNumber="01121237611",
                Address="xyz",
                City = "xyz",
                 PinCode="048-"
            }, "admin123");
            var user = _userManager.Users.FirstOrDefault(b => b.Email == "admin@gamil.com");
           await _userManager.AddToRoleAsync(user, Website.Role_admin);
            throw new NotImplementedException();
        }
    }
}

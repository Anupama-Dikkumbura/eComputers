using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data;
using eComputer.Data.Static;
using eComputer.Data.ViewModels;
using eComputer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComputer.Controllers
{

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var roles = _context.Roles.ToList();
            var userRoles =_context.UserRoles.ToList();
            var usersF = new List<ApplicationUser>();
            List<string> userIds = new List<string>();
            var sales = "";
            var manufacture = "";

            foreach (var role in roles)
            {
                if (role.Name == "Sales") {
                    sales =  role.Id;
                }
                if(role.Name == "Manufacture")
                {
                    manufacture = role.Id;
                }
            }
            foreach(var userrole in userRoles)
            {
                if(userrole.RoleId == sales || userrole.RoleId == manufacture)
                {
                    userIds.Add(userrole.UserId);
                }
            }

            foreach(var user in users)
            {
                foreach(var id in userIds)
                {
                    if(user.Id == id)
                    {
                        usersF.Add(user);
                    }
                }
            }
            
            return View(usersF);
        }

        // Create 

        public IActionResult Create()
        {
            return View(new UserCreateVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateVM userCreateVM)
        {
            if (!ModelState.IsValid) return View(userCreateVM);

            var user = await _userManager.FindByEmailAsync(userCreateVM.EmailAddress);

            if (user != null)
            {
                TempData["Error"] = "This email address already exist!";
                return View(userCreateVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = userCreateVM.FullName,
                UserName = userCreateVM.Username,
                Email = userCreateVM.EmailAddress,
                Address = userCreateVM.Address,
                PhoneNumber = userCreateVM.Phone
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, userCreateVM.Password);

            if (newUserResponse.Succeeded)
            {
                if(userCreateVM.UserRole.ToString() == "Sales")
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Sales);
                }
                if (userCreateVM.UserRole.ToString() == "Manufacture")
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Manufacture);
                }
                if (userCreateVM.UserRole.ToString() == "Admin")
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete User
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) return View("NotFound");

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return View("NotFound");

            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}


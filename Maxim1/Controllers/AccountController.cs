using Maxim1.Models;
using Maxim1.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maxim1.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVM)
        {
            if (!ModelState.IsValid)
            {
                return  View();
            }

            AppUser appUser = new AppUser()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                Email = registerVM.Email,
                UserName = registerVM.UserName

            };
            var result = await userManager.CreateAsync(appUser,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            
            return RedirectToAction(nameof(Login));

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            if (user == null)
            {
                user = await userManager.FindByNameAsync(loginVM.UsernameOrEmail);
                if (user == null) throw new Exception("Username or Email is correct");
            }
            var result= await signInManager.CheckPasswordSignInAsync(user, loginVM.Password,false);
            if (!result.Succeeded) throw new Exception("Username / Email or Password is wrong");
            return RedirectToAction("Index","Home");
        }
    }
}

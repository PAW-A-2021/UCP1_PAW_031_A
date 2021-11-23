using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_031.Models;
using UCP1_PAW_031.Models.ViewModels;

namespace UCP1_PAW_031.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            IdentitySeedData.EnsurePopulated(userMgr).Wait();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser admin = await userManager.FindByNameAsync(loginModel.Name);

                if (admin != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(admin, loginModel.Password, false, false)).Succeeded)
                    {
                        TempData["message"] = $"Welcome back {loginModel.Name}";
                        return Redirect(loginModel?.ReturnUrl?? "/Home/Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}

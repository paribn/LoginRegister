using login.Entities;
using login.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationLoginVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                model.ErrorMessage = "Email or password is wrong";
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthenticationResgisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                model.ErrorMessage = "Email already exists";
            }
            var newUser = new AppUser
            {
                FullName = model.FullName,
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                model.ErrorMessage = string.Join(" ,", result.Errors.Select(x => x.Description));
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }

    }
}

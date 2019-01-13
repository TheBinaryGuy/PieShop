using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PieShop.ViewModels;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel{ ReturnUrl = ReturnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (loginViewModel.ReturnUrl != null)
                    {
                        return LocalRedirect(loginViewModel.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "User Name / Password invalid.");
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register(string ReturnUrl)
        {
            var model = new RegisterViewModel { ReturnUrl = ReturnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new IdentityUser { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            
            if (result.Succeeded)
            {
                if (registerViewModel.ReturnUrl != null)
                {
                    return LocalRedirect(registerViewModel.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

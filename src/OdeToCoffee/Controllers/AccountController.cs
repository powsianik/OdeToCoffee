using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdeToCoffee.Model.Entities;
using OdeToCoffee.ViewModels;

namespace OdeToCoffee.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManger;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManger = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User() {UserName = viewModel.UserName};
            var result = await this.userManger.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }
        }
    }
}
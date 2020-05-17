using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesMVC.ViewModels;

namespace MoviesMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser{
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                   await signInManager.SignInAsync(user, isPersistent:false);
                   return RedirectToAction("index","Users");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }
   
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index","users");
        }

        [HttpGet]
        public IActionResult Login(){
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //var result1 = new IdentityUser {Email = model.Email};
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,  model.RememberMe, lockoutOnFailure:false);
                
                if(result.Succeeded)
                {
                    return RedirectToAction("index", "users");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            
            }
            
            return View();
        }
    }
}
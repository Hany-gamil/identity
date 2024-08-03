using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.viewModel;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller

    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser>signInManager)
        {
            this.userManager=userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Logout ()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }



        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(loginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser userModel=await userManager.FindByNameAsync(userVM.UserName);
               
                if (userModel!= null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found== true)
                    {
                      await  signInManager.SignInAsync(userModel, userVM.RememberMe);
                      return  RedirectToAction("Index", "Home");
                    }
                    
                }
                ModelState.AddModelError("", "username or password wrong");
            }
            return View(userVM);
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(registerViewModel newvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                 userModel.UserName = newvm.username;
                userModel.Email = newvm.Email;
                userModel.PasswordHash = newvm.password;

                IdentityResult result= await userManager.CreateAsync(userModel,newvm.password);
                if (result.Succeeded)
                {
                    // create cookie
                    // List<Claim> claims = new List<Claim>();
                    // claims.Add(new Claim("colour","red"));
                    // await signInManager.SignInWithClaimsAsync(userModel, false, claims);



                    await signInManager.SignInAsync(userModel, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("password",errorItem.Description);
                    }
                }
            }
            return View(newvm);
        }
    }
}

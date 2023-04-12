using Bmerketo_WebApp.Models.Identity;
using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers;

public class AccountController : Controller
{

	//--------------------With Identity--------------------
	private readonly UserManager<CustomIdentityUser> _userManager;
	private readonly SignInManager<CustomIdentityUser> _signInManager;
	private readonly UserService _userService;

    public AccountController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, UserService userService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userService = userService;
    }

    //--------------------Without Identity--------------------
    //public AccountController(UserService userService)
    //{
    //	_userService = userService;
    //}
    //---------------------------END---------------------------


    public IActionResult Index()
	{
		ViewData["Title"] = "Account";

		if (_signInManager.IsSignedIn(User))
		{
			return View();
		}

		return RedirectToAction("index", "home");

	}
	
	//REGISTER
	public IActionResult Register()
	{
		ViewData["Title"] = "Register";
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(AccountRegisterViewModel accountRegisterViewModel)
	{
		ViewData["Title"] = "Register Account";

		if (ModelState.IsValid)
		{
			//--------------------With Identity--------------------
			if (await _userManager.FindByNameAsync(accountRegisterViewModel.Email) == null)
			{
				var result = await _userManager.CreateAsync(accountRegisterViewModel, accountRegisterViewModel.Password);

				if (result.Succeeded)
					return RedirectToAction("login", "account");
			}

			ModelState.AddModelError("", "A User with that E-mail already exists.");


			//--------------------Without Identity--------------------
			//if (await _userService.UserExist(x => x.Email == accountRegisterViewModel.Email))
			//{
			//	ModelState.AddModelError("", "A User with that E-mail already exists.");
			//}
			//else
			//{
			//	if (await _userService.RegisterAsync(accountRegisterViewModel))
			//		return RedirectToAction("login", "account");
			//	else
			//		ModelState.AddModelError("", "Something went wrong while creating the User.");
			//}
            //---------------------------END---------------------------

        }

        return View(accountRegisterViewModel);

	}
	
	//LOGIN
	public IActionResult Login()
	{
		ViewData["Title"] = "Login";
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(AccountLoginViewModel accountLoginViewModel)
	{
		ViewData["Title"] = "Login";

		if (ModelState.IsValid)
		{
			//--------------------With Identity--------------------
			var result = await _signInManager.PasswordSignInAsync(accountLoginViewModel.Email, accountLoginViewModel.Password, false, false);

			if(result.Succeeded)
                return RedirectToAction("index", "account");

            ModelState.AddModelError("", "Incorrect E-mail or Password.");

            //--------------------Without Identity--------------------
            //if (await _userService.LoginAsync(accountLoginViewModel))
            //	return RedirectToAction("index", "account");

            //ModelState.AddModelError("", "Incorrect E-mail or Password.");
            //---------------------------END---------------------------

        }

        return View(accountLoginViewModel);
	}

	//LOGOUT
	public async Task<IActionResult> Logout()
	{
		if(_signInManager.IsSignedIn(User))
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("index", "home");
		}

        return RedirectToAction("login", "account");
    }
}

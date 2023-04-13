using Bmerketo_WebApp.Models.Identity;
using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bmerketo_WebApp.Controllers;

public class AccountController : Controller
{

	//--------------------With Identity--------------------
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly AuthService _auth;
	private readonly UserService _userService;

	public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, UserService userService, AuthService auth)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_userService = userService;
		_auth = auth;
	}

    //--------------------Without Identity--------------------
	//private readonly UserService _userService;

    //public AccountController(UserService userService)
    //{
    //	_userService = userService;
    //}
    //---------------------------END---------------------------

    [Authorize]
	public IActionResult Index()
	{
		ViewData["Title"] = "My Account";

		return View();

        //------------------BEFORE [Authorize]------------------
        //if (_signInManager.IsSignedIn(User))
        //{
        //	return View();
        //}

        //return RedirectToAction("index", "home");
        //---------------------------END---------------------------

    }

    //----REGISTER----
    public IActionResult Register()
	{
		ViewData["Title"] = "Register";
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(AccountRegisterViewModel viewModel)
	{
		ViewData["Title"] = "Register Account";

		if (ModelState.IsValid)
		{
			//---------------With Identity, AuthService---------------
			if (await _auth.RegisterAsync(viewModel))
				return RedirectToAction("login", "account");

			ModelState.AddModelError("", "A User with that E-mail already exists.");


			//---------------With Identity, _userManager---------------
			//if (await _userManager.FindByNameAsync(viewModel.Email) == null)
			//{
			//	var result = await _userManager.CreateAsync(viewModel, viewModel.Password);

			//	if (result.Succeeded)
			//		return RedirectToAction("login", "account");
			//}

			//ModelState.AddModelError("", "A User with that E-mail already exists.");


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

        return View(viewModel);

	}

	//----LOGIN----
	public IActionResult Login()
	{
		ViewData["Title"] = "Login";
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(AccountLoginViewModel viewModel)
	{
		ViewData["Title"] = "Login";

		if (ModelState.IsValid)
		{
			//---------------With Identity, AuthService---------------
			if (await _auth.LoginAsync(viewModel))
				return RedirectToAction("index", "account");

			ModelState.AddModelError("", "Incorrect E-mail or Password.");


			//---------------With Identity, _userManager---------------
			//var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);

			//if(result.Succeeded)
			//             return RedirectToAction("index", "account");

			//         ModelState.AddModelError("", "Incorrect E-mail or Password.");


			//--------------------Without Identity--------------------
			//if (await _userService.LoginAsync(accountLoginViewModel))
			//	return RedirectToAction("index", "account");

			//ModelState.AddModelError("", "Incorrect E-mail or Password.");
			//---------------------------END---------------------------

		}

        return View(viewModel);
	}

    //----LOGOUT----
    [Authorize]
    public async Task<IActionResult> Logout()
	{
		//---------------With Identity, AuthService---------------
		if(await _auth.LogoutAsync(User))
		{
            return RedirectToAction("index", "home");
        }

		return RedirectToAction("login", "account");


        //---------------With Identity, _userManager---------------
        //if (_signInManager.IsSignedIn(User))
        //{
        //	await _signInManager.SignOutAsync();
        //	return RedirectToAction("index", "home");
        //}

        //return RedirectToAction("login", "account");
        //---------------------------END---------------------------
    }
}

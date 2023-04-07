using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers;

public class AccountController : Controller
{
	private readonly UserService _userService;

	public AccountController(UserService userService)
	{
		_userService = userService;
	}

	public IActionResult Index()
	{
		ViewData["Title"] = "Account";

		return View();
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
		ViewData["Title"] = "Register";

		if (ModelState.IsValid)
		{
			if (await _userService.UserExist(x => x.Email == accountRegisterViewModel.Email))
			{
				ModelState.AddModelError("", "A User with that E-mail already exists.");
			}
			else
			{
				if (await _userService.RegisterAsync(accountRegisterViewModel))
					return RedirectToAction("login", "account");
				else
					ModelState.AddModelError("", "Something went wrong while creating the User.");
			}
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
			if(await _userService.LoginAsync(accountLoginViewModel))
				return RedirectToAction("index", "account");

			ModelState.AddModelError("", "Incorrect E-mail or Password.");
		}

		return View(accountLoginViewModel);
	}

}

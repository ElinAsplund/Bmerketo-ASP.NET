using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers;

public class AccountController : Controller
{
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly AuthService _auth;

	public AccountController( SignInManager<IdentityUser> signInManager, AuthService auth)
	{
		_signInManager = signInManager;
		_auth = auth;
	}

    [Authorize]
	public IActionResult Index()
	{
		ViewData["Title"] = "My Account";

		return View();
    }

    //----REGISTER----
    public IActionResult Register()
	{
		ViewData["Title"] = "Register";

        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("index", "account");

        return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(AccountRegisterViewModel viewModel)
	{
		ViewData["Title"] = "Register Account";

		if (ModelState.IsValid)
		{
			if (await _auth.RegisterAsync(viewModel))
				return RedirectToAction("login", "account");

			ModelState.AddModelError("", "A user with that e-mail already exists.");
		}

        return View(viewModel);
	}

	//----LOGIN----
	public IActionResult Login()
	{
		ViewData["Title"] = "Login";

		if (_signInManager.IsSignedIn(User))
            return RedirectToAction("index", "account");

        return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(AccountLoginViewModel viewModel)
	{
		ViewData["Title"] = "Login";

		if (ModelState.IsValid)
		{
			if (await _auth.LoginAsync(viewModel))
				return RedirectToAction("index", "account");

			ModelState.AddModelError("", "Incorrect e-mail or password.");
		}

        return View(viewModel);
	}

    //----LOGOUT----
    [Authorize]
    public async Task<IActionResult> Logout()
	{
		if(await _auth.LogoutAsync(User))
		{
            return RedirectToAction("index", "home");
        }

		return RedirectToAction("login", "account");
    }

    [Authorize]
    public IActionResult AccessDenied()
    {
        ViewData["Title"] = "Access Denied";
        return View();
    }
	
    public IActionResult NewPassword()
    {
        ViewData["Title"] = "New Password";
        return View();
    }
}

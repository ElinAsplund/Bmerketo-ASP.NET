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
	private readonly UserProfileService _userProfileService;


    public AccountController(SignInManager<IdentityUser> signInManager, AuthService auth, UserProfileService userProfileService)
    {
        _signInManager = signInManager;
        _auth = auth;
        _userProfileService = userProfileService;
    }

    //----INDEX----
    [Authorize]
	public async Task<IActionResult> Index()
	{
		var _identityUser = await _userProfileService.GetIdentityUserAsync(User!.Identity!.Name!);

		var viewModel = new AccountIndexViewModel
		{
			Title = "My Account",
			UserProfile = await _userProfileService.GetUserProfileAsync(_identityUser.Id)
        };

        ViewData["Title"] = viewModel.Title;
		return View(viewModel);
    }

    //----REGISTER----
    public IActionResult Register()
	{
		ViewData["Title"] = "Register Account";

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
		ViewData["Title"] = "Try again";
		
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

	//----ACCESS DENIED----
	[Authorize]
    public IActionResult AccessDenied()
    {
        ViewData["Title"] = "Access Denied";
        return View();
    }

	//----NEW PASSWORD----
	public IActionResult NewPassword()
    {
        ViewData["Title"] = "New Password";
        return View();
    }
}

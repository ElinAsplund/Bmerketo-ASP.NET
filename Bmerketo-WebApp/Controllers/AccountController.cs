using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers;

public class AccountController : Controller
{
	public IActionResult Index()
	{
		ViewData["Title"] = "Account";

		return View();
	}
	
	public IActionResult Register()
	{
		ViewData["Title"] = "Register";
		return View();
	}

	[HttpPost]
	public IActionResult Register(AccountRegisterViewModel accountRegisterViewModel)
	{
		ViewData["Title"] = "Register";

		if(ModelState.IsValid)
		{

		}

		return View(accountRegisterViewModel);
	}
	
	public IActionResult Login()
	{
		ViewData["Title"] = "Login";
		return View();
	}
}

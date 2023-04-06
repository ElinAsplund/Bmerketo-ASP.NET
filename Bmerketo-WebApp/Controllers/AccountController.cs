using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult Register()
		{
			ViewData["Title"] = "Register";
			return View();
		}
		
		public IActionResult Login()
		{
			ViewData["Title"] = "Login";
			return View();
		}
	}
}

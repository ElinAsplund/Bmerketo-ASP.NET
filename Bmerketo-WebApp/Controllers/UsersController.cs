using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //----INDEX----
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin - Dashboard";

            return View();
        }
    }
}

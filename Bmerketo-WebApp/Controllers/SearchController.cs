using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class SearchController : Controller
    {
        //----INDEX----
        public IActionResult Index()
        {
            ViewData["Title"] = "Search";
            return View();
        }
    }
}

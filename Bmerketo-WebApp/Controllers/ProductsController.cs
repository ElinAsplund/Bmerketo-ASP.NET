using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

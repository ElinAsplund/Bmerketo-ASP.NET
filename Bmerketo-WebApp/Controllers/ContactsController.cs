using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

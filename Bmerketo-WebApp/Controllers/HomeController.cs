using Bmerketo_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";

            
            var showcase = new ShowcaseModel()
            {
                Ingress = "WELCOME TO BMERKETO SHOP",
                Title = "Exclusive Chair gold Collection.",
                Button = new LinkButtonModel()
                {
                    Url = "/products",
                    Content = "SHOP NOW"
                },
                ImageUrl = "./images/chair.jpg"
            };
            

            return View(showcase);
        }
    }
}

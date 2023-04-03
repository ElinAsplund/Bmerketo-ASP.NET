using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";

            
            var viewModel = new HomeIndexViewModel()
            {
                Showcase_1 = new ShowcaseModel()
                {
                    Ingress = "WELCOME TO BMERKETO SHOP",
                    Title = "Exclusive Chair gold Collection.",
                    Button = new LinkButtonModel()
                    {
                        Url = "/products",
                        Content = "SHOP NOW"
                    },
                    ImageUrl = "./images/chair.jpg"
                },
                Showcase_2 = new ShowcaseModel()
                {
                    Ingress = "SHOP SHOP SHOP SHOP SHOP",
                    Title = "Mighty golden throne Collection.",
                    Button = new LinkButtonModel()
                    {
                        Url = "/products",
                        Content = "SHOP NOW"
                    },
                    ImageUrl = "./images/chair.jpg"
                }
            };


            return View(viewModel);
        }
    }
}

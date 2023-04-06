using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View();
        }
        
        public IActionResult Details()
        {
            ViewData["Title"] = "Product Details";

			var viewModel = new ProductDetailsViewModel
			{
				ShopHero = new HeroModel
				{
					Heading = "SHOP",
					Subheading = "HOME. PRODUCT DETAILS"
				},
				RelatedShoes = new RelatedProductsViewModel
				{
					GridCards = new List<GridCollectionCardViewModel>
					{
						new GridCollectionCardViewModel{ Id ="1", Title = "Apple watch series", Price = 10, ImageUrl = "/images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="2", Title = "Apple watch series", Price = 20, ImageUrl = "/images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="3", Title = "Apple watch series", Price = 30, ImageUrl = "/images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="4", Title = "Apple watch series", Price = 40, ImageUrl = "/images/product.jpg" }
					}
				}
			};

			return View(viewModel);
        }
    }
}

using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class ProductsController : Controller
    {
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
        {
            ViewData["Title"] = "Products";

			var viewmodel = new ProductsIndexViewModel
			{
				All = new GridCollectionViewModel
				{
					Title = "All Products",
					GridCards = new List<GridCollectionCardViewModel>
					{
						new GridCollectionCardViewModel{ Id ="1", Title = "Apple watch series", Price = 10, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="2", Title = "Apple watch series", Price = 20, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="3", Title = "Apple watch series", Price = 30, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="4", Title = "Apple watch series", Price = 40, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="5", Title = "Apple watch series", Price = 50, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="6", Title = "Apple watch series", Price = 60, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="7", Title = "Apple watch series", Price = 70, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="8", Title = "Apple watch series", Price = 80, ImageUrl = "./images/product.jpg" }
					},
					LoadMore = false
				}
			};

            return View(viewmodel);
        }
        
        public IActionResult Details()
        {
            ViewData["Title"] = "Product Details";

			var viewModel = new ProductsDetailsViewModel
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

		//----PRODUCT LIST----
		[Authorize]
		public IActionResult List()
		{
			ViewData["Title"] = "Product List";

			return View();
		}


        //----REGISTER PRODUCT----
        [Authorize]
        public IActionResult Register()
		{
			ViewData["Title"] = "Register Product";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(ProductRegisterViewModel viewModel)
		{
			ViewData["Title"] = "Register Product";

			if (ModelState.IsValid)
			{
				try 
				{
					if (await _productService.RegisterAsync(viewModel))
						return RedirectToAction("register", "products");
					else
						ModelState.AddModelError("", "Something went wrong while creating the product.");
				}
				catch 
				{
					ModelState.AddModelError("", "Something went wrong while creating the product.");
				}

			}

			return View(viewModel);
		}
	}
}

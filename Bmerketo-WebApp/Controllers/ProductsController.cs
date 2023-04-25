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
                        new GridCollectionCardViewModel{ Id ="1", Title = "Apple watch series", Price = 10, ImageUrl = "https://images.pexels.com/photos/7897470/pexels-photo-7897470.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="2", Title = "Apple watch series", Price = 20, ImageUrl = "https://images.pexels.com/photos/1667071/pexels-photo-1667071.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="3", Title = "Apple watch series", Price = 30, ImageUrl = "https://images.pexels.com/photos/37539/colored-pencils-colour-pencils-mirroring-color-37539.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="4", Title = "Apple watch series", Price = 40, ImageUrl = "https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="5", Title = "Apple watch series", Price = 50, ImageUrl = "https://images.pexels.com/photos/2783873/pexels-photo-2783873.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="6", Title = "Apple watch series", Price = 60, ImageUrl = "https://images.pexels.com/photos/2849742/pexels-photo-2849742.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="7", Title = "Apple watch series", Price = 70, ImageUrl = "https://images.pexels.com/photos/2465877/pexels-photo-2465877.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="8", Title = "Apple watch series", Price = 80, ImageUrl = "https://images.pexels.com/photos/1207918/pexels-photo-1207918.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
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
                        new GridCollectionCardViewModel{ Id ="1", Title = "Apple watch series", Price = 10, ImageUrl = "https://images.pexels.com/photos/7897470/pexels-photo-7897470.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="2", Title = "Apple watch series", Price = 20, ImageUrl = "https://images.pexels.com/photos/1667071/pexels-photo-1667071.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="3", Title = "Apple watch series", Price = 30, ImageUrl = "https://images.pexels.com/photos/37539/colored-pencils-colour-pencils-mirroring-color-37539.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                        new GridCollectionCardViewModel{ Id ="4", Title = "Apple watch series", Price = 40, ImageUrl = "https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    }
                }
			};

			return View(viewModel);
        }

        //----PRODUCT LIST----
        //[Authorize(Roles = "admin")]
        public IActionResult List()
		{
			ViewData["Title"] = "Product List";

			return View();
		}


        //----REGISTER PRODUCT----
        //[Authorize(Roles = "admin")]
        public IActionResult Register()
		{
			ViewData["Title"] = "Register Product";

			return View();
		}

        //[Authorize(Roles = "admin")]
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

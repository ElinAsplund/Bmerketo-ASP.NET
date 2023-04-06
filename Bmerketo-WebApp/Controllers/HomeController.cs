using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel 
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
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
                    LoadMore = true
                },
				TopSellingCollection = new GridCollectionViewModel
				{
					Title = "Top selling products in this week",
					GridCards = new List<GridCollectionCardViewModel>
					{
						new GridCollectionCardViewModel{ Id ="1", Title = "Apple watch series", Price = 10, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="2", Title = "Apple watch series", Price = 20, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="3", Title = "Apple watch series", Price = 30, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="4", Title = "Apple watch series", Price = 40, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="5", Title = "Apple watch series", Price = 50, ImageUrl = "./images/product.jpg" },
						new GridCollectionCardViewModel{ Id ="6", Title = "Apple watch series", Price = 60, ImageUrl = "./images/product.jpg" }
					},
                    LoadMore = true
                },
                LampSpotlight = new SpotlightViewModel 
                {
                    SpotlightCards = new List<SpotlightCardViewModel>
                    {
                        new SpotlightCardViewModel{ Id="1", Title = "Wall lamp 1562 LTG modal", UserName = "Admin", CommentsTotal = 13 , Description = "Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl="./images/wall-lamp.jpg"},
                        new SpotlightCardViewModel{ Id="2", Title = "Wall lamp 1562 LTG modal", UserName = "HurrDurr", CommentsTotal = 14 , Description = "Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl="./images/wall-lamp.jpg"},
                        new SpotlightCardViewModel{ Id="3", Title = "Wall lamp 1337 LTG modal", UserName = "KurrFnurr", CommentsTotal = 15 , Description = "Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl="./images/wall-lamp.jpg"}
                    }
                }
			};

            return View(viewModel);
        }
    }
}
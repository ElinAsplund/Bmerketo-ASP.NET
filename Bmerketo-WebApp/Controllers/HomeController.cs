using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GridCollectionCardService _gridCollectionCardService;

        public HomeController(GridCollectionCardService gridCollectionCardService)
        {
            _gridCollectionCardService = gridCollectionCardService;
        }

        //REFERENCE categories
        //-----------------------------
        //CategoryId = 1 => "new"
        //CategoryId = 2 => "popular"
        //CategoryId = 3 => "featured"

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel 
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                    GridCards = await _gridCollectionCardService.PopulateCardsByCategoryIdAsync(x => x.CategoryId == 3), //CategoryId = 3 => "featured"
                    LoadMore = true
                },
                NewCollection = new GridCollectionViewModel 
                {
                    Title = "News",
                    Categories = new List<string> {"Bags", "Dress", "Decoration", "Beauty" },
                    GridCards = await _gridCollectionCardService.PopulateCardsByCategoryIdAsync(x => x.CategoryId == 1), //CategoryId = 1 => "new"
                    LoadMore = false
                },
				TopSellingCollection = new GridCollectionViewModel
				{
					Title = "Top selling products in this week",
                    GridCards = await _gridCollectionCardService.PopulateCardsByCategoryIdAsync(x => x.CategoryId == 2), //CategoryId = 2 => "popular"
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

			ViewData["Title"] = viewModel.Title;
			return View(viewModel);
        }
    }
}
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bmerketo_WebApp.Controllers
{
    //REMOVED THIS DURING DEVELOPMENT, I HOPE I REMEBER TO TURN IT ON!
	//[Authorize(Roles = "admin")]
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
            ViewData["Title"] = "Users";

            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(UsersIndexViewModel viewModel)
        {
            ViewData["Title"] = "Users";

            //ERROR! ALL THE USERS ROLES CHANGES WHEN THE VIEWMODEL CHANGES... ofc.
            //Maybe it will work with the service going? 
            //Or just the RedirectToAction("index", "users") solves the problem!? 
            //--By rerendering the page with the changes taken from the database?

            //The right information go through:
            var role = viewModel.Role;
            var userId = viewModel.UserId;

            if (ModelState.IsValid)
            {
                //MOCK-UP CODE
                //if (await _roleService.ChangeRoleAsync(viewModel))
                //    return RedirectToAction("index", "users");

                //ModelState.AddModelError("", "No changes have been made, and the role remains the same as before.");
                //ModelState.AddModelError("", "Something went wrong!");
            }

            //return View(viewModel);
            return RedirectToAction("index", "users");
        }
    }
}

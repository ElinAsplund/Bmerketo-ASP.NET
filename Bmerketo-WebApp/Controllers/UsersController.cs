using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    //REMOVED THIS DURING DEVELOPMENT, I HOPE I REMEBER TO TURN IT ON! :D
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
	{
        public readonly RoleService _roleService;

        public UsersController(RoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
		{
            ViewData["Title"] = "Users";

            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(UsersIndexViewModel viewModel)
        {
            ViewData["Title"] = "Users";

            //Check's if the right information go through:
            //var roleChange = viewModel.Role;
            //var userId = viewModel.UserId;

            if (ModelState.IsValid)
            {
                //POSSIBLE ERROR-MSGs:
                //ModelState.AddModelError("", "No changes have been made, and the role remains the same as before.");
                //ModelState.AddModelError("", "Something went wrong!");

                if(await _roleService.ChangeRoleAsync(viewModel.UserId, viewModel.Role))
                    return RedirectToAction("index", "users");

            }
            
            //THIS RENDERS ALL THE USERS ROLE TO THE VIEWMODELS ROLE. Example, all user get the ADMIN role (NOT IN DB, just in the frontend):
            //return View(viewModel);

            return RedirectToAction("index", "users");
        }

        public IActionResult Register()
        {
            ViewData["Title"] = "Register User";

            return View();
        }
    }
}

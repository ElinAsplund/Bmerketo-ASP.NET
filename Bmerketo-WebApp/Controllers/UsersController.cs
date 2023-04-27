using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    //REMOVED THIS DURING DEVELOPMENT, I HOPE I REMEBER TO TURN IT ON! :D
    //[Authorize(Roles = "admin")]
    public class UsersController : Controller
	{
        public readonly RoleService _roleService;
        public readonly UserProfileService _userProfileService;
        public readonly AuthService _authService;

        public UsersController(RoleService roleService, UserProfileService userProfileService, AuthService authService)
        {
            _roleService = roleService;
            _userProfileService = userProfileService;
            _authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new UsersIndexViewModel
            {
                Title = "Users",
                UserModels = await _userProfileService.GetAllUserModelAsync(),
                AllRoles = await _roleService.GetRolesAsync()
            };

            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
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

        public async Task<IActionResult> Register()
        {
            var viewModel = new UsersRegisterViewModel
            {
                Title = "Register User",
                AllRoles = await _roleService.GetRolesAsync()
                //Checkboxes = await _checkBoxOptionService.PopulateRoleCheckBoxesAsync()
            };

            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsersRegisterViewModel viewModel)
        {
            ViewData["Title"] = "Register Account";

            if (ModelState.IsValid)
            {
                if (await _authService.RegisterAsync(viewModel))
                {
                    ModelState.Clear();

                    //Clear form:
                    viewModel.FirstName = "";
                    viewModel.LastName = "";
                    viewModel.StreetName = "";
                    viewModel.PostalCode = "";
                    viewModel.City = "";
                    viewModel.PhoneNumber = "";
                    viewModel.CompanyName = "";
                    viewModel.Email = "";
                    viewModel.ProfileImage = "";

                    return View(viewModel);
                }

                ModelState.AddModelError("", "A user with that e-mail already exists.");
            }

            return View(viewModel);
        }
    }
}

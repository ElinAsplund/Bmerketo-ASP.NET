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
        public readonly UserService _userService;
        public readonly AuthService _authService;

        public UsersController(RoleService roleService, UserService userService, AuthService authService)
        {
            _roleService = roleService;
            _userService = userService;
            _authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new UsersIndexViewModel
            {
                Title = "Users",
                UserModels = await _userService.GetAllUserModelAsync(),
                AllRoles = await _roleService.GetRolesAsync()
            };

            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
		}

        [HttpPost]
        public async Task<IActionResult> Index(UsersIndexViewModel viewModel)
        {
            viewModel.Title = "Users";
            viewModel.UserModels = await _userService.GetAllUserModelAsync();
            viewModel.AllRoles = await _roleService.GetRolesAsync();

            ViewData["Title"] = viewModel.Title;

            if (ModelState.IsValid)
            {
                if (await _roleService.ChangeRoleAsync(viewModel.UserId, viewModel.Role))
                {
                    TempData["SuccessMessage"] = "The user was updated successfully!";
                    return RedirectToAction("index", "users");
                }
                else
                    ModelState.AddModelError("", "Something went wrong, no changes have been made!");

                return View(viewModel);
            }

            ModelState.AddModelError("", "Something went wrong, no changes have been made!");

            return View(viewModel);
        }

        public async Task<IActionResult> Register()
        {
            var viewModel = new UsersRegisterViewModel
            {
                Title = "Register User",
                AllRoles = await _roleService.GetRolesAsync()
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

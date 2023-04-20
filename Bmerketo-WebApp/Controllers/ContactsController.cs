using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class ContactsController : Controller
    {
		private readonly ContactService _contactService;

		public ContactsController(ContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
        {
			ViewData["Title"] = "Contact";
            return View();
        }

	    [HttpPost]
	    public async Task<IActionResult> Index(ContactRegisterViewModel viewModel)
	    {
		    ViewData["Title"] = "Contact";

			if (ModelState.IsValid)
			{
				try
				{
					if (await _contactService.RegisterAsync(viewModel))
					{
                        ModelState.Clear();

						//Clear form
						viewModel.FullName = "";
						viewModel.Email = "";
						viewModel.PhoneNumber = "";
						viewModel.CompanyName = "";
						viewModel.Comment = "";

                        ModelState.AddModelError("", "Your comment has now been sent!");
                        return View(viewModel);
                    }
					else
						ModelState.AddModelError("", "Something went wrong while posting the comment.");
				}
				catch
				{
					ModelState.AddModelError("", "Something went wrong while posting the comment.");
				}

			}

			return View(viewModel);
	    }
    }
}

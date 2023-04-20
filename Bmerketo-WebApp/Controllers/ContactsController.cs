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

			//var viewModel = new ContactsIndexViewModel
   //         {
   //             ContactHero = new HeroModel
   //             {
   //                 Heading = "CONTACT",
   //                 Subheading = "HOME. CONTACT"
   //             }
   //         };

            //return View(viewModel);
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
						return RedirectToAction("index", "contacts");
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

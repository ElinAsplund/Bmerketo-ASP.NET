﻿using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
			ViewData["Title"] = "Contact";

			var viewModel = new ContactsIndexViewModel
            {
                ContactHero = new HeroModel
                {
                    Heading = "CONTACT",
                    Subheading = "HOME. CONTACT"
                }
            };

            return View(viewModel);
        }

	    [HttpPost]
	    public async Task<IActionResult> Index(ContactRegisterViewModel viewModel)
	    {
		    ViewData["Title"] = "Contact";

		    return View(viewModel);
	    }
    }
}

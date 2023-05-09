﻿using Bmerketo_WebApp.Models;
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
			var viewModel = new ContactsIndexViewModel
			{
				Title = "Contact",
				ContactHero = new HeroModel 
				{ 
					Heading = "CONTACT", 
					Subheading = "HOME. CONTACT",
					BackgroundImg = "/images/header.jpg"
                },
			};

			ViewData["Title"] = viewModel.Title;
			return View(viewModel);
        }

	    [HttpPost]
	    public async Task<IActionResult> Index(ContactFormViewModel contactFormViewModel)
	    {
			var viewModel = new ContactsIndexViewModel
			{
				Title = "Contact",
				ContactHero = new HeroModel { Heading = "CONTACT", Subheading = "HOME. CONTACT", BackgroundImg = "/images/header.jpg" },
				ContactForm = contactFormViewModel
			};

			if (ModelState.IsValid)
			{
				try
				{
					if (await _contactService.RegisterAsync(viewModel.ContactForm))
					{
						ModelState.Clear();

						//Clear form
						viewModel.ContactForm.FullName = "";
						viewModel.ContactForm.Email = "";
						viewModel.ContactForm.PhoneNumber = "";
						viewModel.ContactForm.CompanyName = "";
						viewModel.ContactForm.Comment = "";


                        TempData["SuccessMessage"] = "Your comment has now been sent!";
						ViewData["Title"] = "Comment sent";
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

			ViewData["Title"] = viewModel.Title;
			return View(viewModel);
	    }
    }
}

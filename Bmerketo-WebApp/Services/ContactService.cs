﻿using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;

namespace Bmerketo_WebApp.Services;

public class ContactService
{
	private readonly DataContext _context;

	public ContactService(DataContext context)
	{
		_context = context;
	}

	public async Task<bool> RegisterAsync(ContactFormViewModel viewModel)
	{
		try
		{
			ContactEntity contactEntity = viewModel;

			_context.Contacts.Add(contactEntity);
			await _context.SaveChangesAsync();

			return true;
		}
		catch
		{
			return false;
		}
	}
}

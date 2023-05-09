using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bmerketo_WebApp.Services;

public class AuthService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly IdentityContext _identityContext;
	private readonly SignInManager<IdentityUser> _signInManager;

	public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager)
	{
		_userManager = userManager;
		_identityContext = identityContext;
		_signInManager = signInManager;
	}

	public async Task<bool> RegisterAsync(AccountRegisterViewModel viewModel)
	{
		try
		{
			var roleName = "user";

			if(!await _userManager.Users.AnyAsync())
				roleName = "admin";

			IdentityUser identityUser = viewModel;
			await _userManager.CreateAsync(identityUser, viewModel.Password);

			await _userManager.AddToRoleAsync(identityUser, roleName);

			AddressEntity addressEntity = viewModel;
			_identityContext.Addresses.Add(addressEntity);
			await _identityContext.SaveChangesAsync();

			UserProfileEntity userProfileEntity = viewModel;
			userProfileEntity.UserId = identityUser.Id;
			userProfileEntity.AddressId = addressEntity.Id;
			//userProfileEntity.Address.Id = addressEntity.Id;


			var test = userProfileEntity;

			_identityContext.UserProfiles.Add(userProfileEntity);
			await _identityContext.SaveChangesAsync();
			
			return true;
		}
		catch { return false; }
	}

	public async Task<bool> RegisterAsync(UsersRegisterViewModel viewModel)
	{
		try
		{
			IdentityUser identityUser = viewModel;
			await _userManager.CreateAsync(identityUser, viewModel.Password);

			if(viewModel.Role != null)
				await _userManager.AddToRoleAsync(identityUser, viewModel.Role);

			UserProfileEntity userProfileEntity = viewModel;
			userProfileEntity.UserId = identityUser.Id;

			_identityContext.UserProfiles.Add(userProfileEntity);
			await _identityContext.SaveChangesAsync();
			
			return true;
		}
		catch { return false; }
	}
	
	public async Task<bool> LoginAsync(AccountLoginViewModel viewModel)
	{
		try
		{
			var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.KeepLoggedIn, false);
			
			return result.Succeeded;
		}
		catch { return false; }
	}
	
	public async Task<bool> LogoutAsync(ClaimsPrincipal user)
	{
		await _signInManager.SignOutAsync();

		return _signInManager.IsSignedIn(user);
	}
}

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
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly SeedService _seedService;

	public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
	{
		_userManager = userManager;
		_identityContext = identityContext;
		_signInManager = signInManager;
		_seedService = seedService;
		_roleManager = roleManager;
	}

	public async Task<bool> RegisterAsync(AccountRegisterViewModel viewModel)
	{
		try
		{
			await _seedService.SeedRoles();
			var roleName = "user";

			if(!await _userManager.Users.AnyAsync())
				roleName = "admin";

			IdentityUser identityUser = viewModel;
			await _userManager.CreateAsync(identityUser, viewModel.Password);

			await _userManager.AddToRoleAsync(identityUser, roleName);

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

using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Services;

public class UserProfileService
{
	private readonly IdentityContext _identityContext;
	private readonly RoleService _roleService;

    public UserProfileService(IdentityContext identityContext, RoleService roleService)
    {
        _identityContext = identityContext;
        _roleService = roleService;
    }

    public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
	{
		var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
		return userProfileEntity!;
	}

	public async Task<IdentityUser> GetIdentityUserAsync(string email)
	{
		var identityUser = await _identityContext.Users.FirstOrDefaultAsync(x => x.Email == email);

		return identityUser!;
	}

 //   public async Task<IEnumerable<UserProfileEntity>> GetAllUserProfileAsync()
 //   {
 //       var userProfiles = new List<UserProfileEntity>();
 //       var userProfileEntity = await _identityContext.UserProfiles.ToListAsync();

 //       foreach (var profile in userProfileEntity)
 //       {
 //           userProfiles.Add(profile);
 //       }

	//	return userProfiles!;
	//}

    public async Task<IEnumerable<UserModel>> GetAllUserModelAsync()
    {
        var userModels = new List<UserModel>();
        var userProfileEntities = await _identityContext.UserProfiles.Include(x => x.User).ToListAsync();

        var roles = await _roleService.GetUserRolesAsync();

        foreach (var user in userProfileEntities)
        {

            UserModel userModel = user;

            var foundRole = roles.FirstOrDefault(x => x.Id == userModel.Id);

            userModel.Role = foundRole!.RoleName;

            userModels.Add(userModel);
        }

        return userModels!;
	}
}

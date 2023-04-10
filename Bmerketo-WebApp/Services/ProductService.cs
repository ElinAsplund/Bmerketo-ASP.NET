using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using System.Linq.Expressions;

namespace Bmerketo_WebApp.Services;

public class ProductService
{
	private readonly DataContext _context;

	public ProductService(DataContext context)
	{
		_context = context;
	}

	//public async Task<bool> UserExist(Expression<Func<UserEntity, bool>> predicate)
	//{
	//	if (await _context.Users.AnyAsync(predicate))
	//		return true;

	//	return false;
	//}

	public async Task<bool> RegisterAsync(ProductRegisterViewModel productRegisterViewModel)
	{
		try
		{
			//converts to entity
			ProductEntity productEntity = productRegisterViewModel;

			//create user
			_context.Products.Add(productEntity);
			await _context.SaveChangesAsync();

			return true;
		}
		catch
		{
			return false;
		}
	}

	//public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
	//{
	//	var userEntity = await _context.Users.FirstOrDefaultAsync(predicate);

	//	return userEntity!;
	//}

	//public async Task<bool> LoginAsync(AccountLoginViewModel accountLoginViewModel)
	//{
	//	var userEntity = await GetAsync(x => x.Email == accountLoginViewModel.Email);

	//	if (userEntity != null)
	//		return userEntity.VerifySecurePassword(accountLoginViewModel.Password);

	//	return false;
	//}
}

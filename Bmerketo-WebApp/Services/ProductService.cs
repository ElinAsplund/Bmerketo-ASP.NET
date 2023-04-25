using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Bmerketo_WebApp.Services;

public class ProductService
{
	private readonly ProductContext _context;

	public ProductService(ProductContext context)
	{
		_context = context;
	}

	//public async Task<bool> UserExist(Expression<Func<UserEntity, bool>> predicate)
	//{
	//	if (await _context.Users.AnyAsync(predicate))
	//		return true;

	//	return false;
	//}

	public async Task<bool> RegisterAsync(ProductRegisterViewModel viewModel)
	{
		try
		{
			//converts to entity
			ProductEntity productEntity = viewModel;

            //create product
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

			//get the currentCategory so the id can be used
			var currentCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Name == viewModel.Category);

			//converts to ProductCategoryEntity
			var productCategoryEntity = new ProductCategoryEntity
			{
				ProductId = productEntity.Id,
				CategoryId = currentCategory!.Id
			};

			_context.ProductsCategories.Add(productCategoryEntity);
			await _context.SaveChangesAsync();

			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task<IEnumerable<ProductModel>> GetAllAsync()
	{
		var products = new List<ProductModel>();
		var categoriesEntities = new List<CategoryEntity>();
		var items = await _context.Products.ToListAsync();
		var productCategories = await _context.ProductsCategories.Include(x => x.Category).ToListAsync();

        foreach (var product in items)
		{
			ProductModel productModel = product;

			foreach (var item in productCategories)
			{
				if (item.ProductId == product.Id)
				{
                    productModel.Categories.Add(item.Category);
				}
			}
			
			products.Add(productModel);
		}

		return products;
	}

    public async Task<bool> RemoveAsync(ProductModel productModel)
    {
        try
        {
            //converts to entity
            ProductEntity selectedProductEntity = productModel;

            var dbProductEntity = await _context.Products.FirstOrDefaultAsync(x => x.Id == productModel.Id);

            //create user
			if(dbProductEntity != null)
			{
				_context.Products.Remove(dbProductEntity);
				await _context.SaveChangesAsync();

				return true;
			}

			return false;
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

using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using System.Linq.Expressions;

namespace Bmerketo_WebApp.Services;

public class GridCollectionCardService
{
	private readonly ProductService _productService;

	public GridCollectionCardService(ProductService productService)
	{
		_productService = productService;
	}

	public async Task<IEnumerable<GridCollectionCardViewModel>> PopulateCardsAsync()
	{
		var cards = new List<GridCollectionCardViewModel>();
		var products = await _productService.GetAllAsync();

		foreach (var product in products)
		{
			GridCollectionCardViewModel card = product;

			cards.Add(card);
		}

		return cards;
	}
	
	public async Task<IEnumerable<GridCollectionCardViewModel>> PopulateCardsByCategoryIdAsync(Expression<Func<ProductCategoryEntity, bool>> predicate)
	{
		var cards = new List<GridCollectionCardViewModel>();
		var products = await _productService.GetProductsByCategoryIdAsync(predicate);

		foreach (var product in products)
		{
			GridCollectionCardViewModel card = product;

			cards.Add(card);
		}

		return cards;
	}
}

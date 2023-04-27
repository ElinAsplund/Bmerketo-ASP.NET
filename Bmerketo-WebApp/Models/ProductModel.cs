﻿using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;

namespace Bmerketo_WebApp.Models;

public class ProductModel
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public decimal Price { get; set; } = 0;
	public string? LgImgUrl { get; set; }
	public string? SmImgUrl { get; set; }

	public List<CategoryEntity> Categories = new(); //NO NEED?


    #region implicit operators

    public static implicit operator GridCollectionCardViewModel(ProductModel model)
    {
		return new GridCollectionCardViewModel
		{
			Id = model.Id,
			Title = model.Name,
			ImageUrl = model.LgImgUrl!,
			Price = model.Price
		};
    }

    #endregion
}

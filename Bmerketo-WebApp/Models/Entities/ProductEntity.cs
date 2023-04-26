﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

public class ProductEntity
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;

	[Column(TypeName = "money")]
	public decimal Price { get; set; } = 0;

	public string? LgImgUrl { get; set; }
	public string? SmImgUrl { get; set; }

	public ICollection<ProductCategoryEntity> ProductCategories = new HashSet<ProductCategoryEntity>();
	public ICollection<CategoryEntity> Categories = new HashSet<CategoryEntity>(); //Dont need?


    #region implicit operators
    public static implicit operator ProductModel(ProductEntity productEntity)
	{
		return new ProductModel
		{
			Id = productEntity.Id,
			Name = productEntity.Name,
			Description = productEntity.Description,
			Price = productEntity.Price,
			LgImgUrl = productEntity.LgImgUrl!,
			SmImgUrl = productEntity.SmImgUrl!,
			//Categories = productEntity.Categories
		};
	}
	
	public static implicit operator ProductEntity(ProductModel productModel)
	{
		return new ProductEntity
		{
			//Id = productModel.Id,
			Name = productModel.Name,
			Description = productModel.Description,
			Price = productModel.Price,
			LgImgUrl = productModel.LgImgUrl,
			SmImgUrl = productModel.SmImgUrl,
			//Categories = productModel.Categories.Name
		};
	}
	#endregion
}

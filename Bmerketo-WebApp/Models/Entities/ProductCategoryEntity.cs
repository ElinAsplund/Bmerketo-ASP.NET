﻿using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategoryEntity
{
	public int ProductId { get; set; }
	public int CategoryId { get; set; }

	public ProductEntity Product { get; set; } = null!;
	public CategoryEntity Category { get; set; } = null!;
}

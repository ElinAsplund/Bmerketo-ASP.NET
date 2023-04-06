﻿using Bmerketo_WebApp.Models;

namespace Bmerketo_WebApp.ViewModels;

public class ProductsDetailsViewModel
{
	public string Title { get; set; } = "Product";
	public HeroModel ShopHero { get; set; } = null!;
	public RelatedProductsViewModel RelatedShoes { get; set; } = null!;
}
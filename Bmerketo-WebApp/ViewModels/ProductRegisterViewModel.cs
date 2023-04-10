using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class ProductRegisterViewModel
{
	[Display(Name = "Product Name*")]
	[Required(ErrorMessage = "Please enter the Product Name.")]
	public string Name { get; set; } = null!;


	[Display(Name = "Product Description*")]
	[Required(ErrorMessage = "Please enter the Product Description.")]
	public string Description { get; set; } = null!;


	[Display(Name = "Product Price*")]
	[Required(ErrorMessage = "Please enter the Product Price.")]
	public decimal Price { get; set; } = 0;


	[Display(Name = "Product Image* (501*430px)")]
	[Required(ErrorMessage = "Please enter a Product Image.")]
	public string LgImgUrl { get; set; } = null!;


	[Display(Name = "Product Image* (120*113px)")]
	[Required(ErrorMessage = "Please enter a Product Image.")]
	public string SmImgUrl { get; set; } = null!;

	//Probably need to make a category model here to make it work...!?
	//[Display(Name = "Categories (optional)")]
	//public string? Category { get; set; }

}

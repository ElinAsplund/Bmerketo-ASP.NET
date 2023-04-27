using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class ProductRegisterViewModel
{
	public string? Title { get; set; }

	[Display(Name = "Product Name*")]
	[Required(ErrorMessage = "Please enter the product name.")]
	public string Name { get; set; } = null!;


	[Display(Name = "Product Description*")]
	[Required(ErrorMessage = "Please enter the product description.")]
	public string Description { get; set; } = null!;


	[Display(Name = "Product Price*")]
	[Required(ErrorMessage = "Please enter the product price.")]
	[DataType(DataType.Currency)]
	public decimal Price { get; set; }


	[Display(Name = "Large Product Image")]
	public string? LgImgUrl { get; set; }


	[Display(Name = "Small Product Image")]
	public string? SmImgUrl { get; set; }

    public List<CheckboxOptionModel> Checkboxes { get; set; } = new();

    public List<int> CheckboxCategoryId { get; set; } = new();



	#region implicit operators

	public static implicit operator ProductEntity(ProductRegisterViewModel productRegisterViewModel)
	{
		return new ProductEntity
		{
			Name = productRegisterViewModel.Name,
			Description = productRegisterViewModel.Description,
			Price = productRegisterViewModel.Price,
			LgImgUrl = productRegisterViewModel.LgImgUrl,
			SmImgUrl = productRegisterViewModel.SmImgUrl
		};
	}

	#endregion
}

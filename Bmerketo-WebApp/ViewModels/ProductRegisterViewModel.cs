using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;
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
	[DataType(DataType.Currency)]
	public decimal Price { get; set; } = 0;


	[Display(Name = "Large Product Image")]
	public string? LgImgUrl { get; set; }


	[Display(Name = "Small Product Image")]
	public string? SmImgUrl { get; set; }

	//[Display(Name = "Product category:")]
	//public string Category { get; set; } = null!;

	//[Display(Name = "Category (optional)")]
	//public string[] Category { get; set; } = null!;

	//public bool IsActive { get; set; } = false;

    //public List<CheckboxOptionModel> Checkboxes { get; set; } = new(); NO NEED?

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

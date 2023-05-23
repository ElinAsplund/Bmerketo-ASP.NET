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


	[Display(Name = "Large Product Image (optional)")]
	public string? LgImgUrl { get; set; }


	[Display(Name = "Small Product Image (optional)")]
	public string? SmImgUrl { get; set; }

    public List<CheckboxOptionModel> Checkboxes { get; set; } = new();

    public List<int> CheckboxCategoryId { get; set; } = new();



    //TEEEST

    [Display(Name = "Image TEST (optional)")]
    [DataType(DataType.Upload)]
	public IFormFile? ImageTest { get; set; }

    //TEEEST





    #region implicit operators

    //public static implicit operator ProductEntity(ProductRegisterViewModel productRegisterViewModel)
    //{
    //	return new ProductEntity
    //	{
    //		Name = productRegisterViewModel.Name,
    //		Description = productRegisterViewModel.Description,
    //		Price = productRegisterViewModel.Price,
    //		LgImgUrl = productRegisterViewModel.LgImgUrl,
    //		SmImgUrl = productRegisterViewModel.SmImgUrl
    //	};
    //}


    //TEEEST
    public static implicit operator ProductEntity(ProductRegisterViewModel viewModel)
	{
		var productEntity = new ProductEntity
		{
			Name = viewModel.Name,
			Description = viewModel.Description,
			Price = viewModel.Price,
			LgImgUrl = viewModel.LgImgUrl,
			SmImgUrl = viewModel.SmImgUrl
		};

		if(viewModel.ImageTest != null )
		{
			productEntity.LgImgUrl = $"{Guid.NewGuid()}_{viewModel.ImageTest.FileName}";
		}

		return productEntity;
	}
    //TEEEST

    #endregion
}

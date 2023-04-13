using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class AccountRegisterViewModel
{
	[Display(Name = "First Name*")]
	[Required(ErrorMessage = "Please enter your First Name.")]
	[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a valid First Name.")]
	public string FirstName { get; set; } = null!;
	

	[Display(Name = "Last Name*")]
	[Required(ErrorMessage = "Please enter your Last Name.")]
	[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a valid Last Name.")]
	public string LastName { get; set; } = null!;
	

	[Display(Name = "Street Name*")]
	[Required(ErrorMessage = "Please enter your Street Name.")]
	public string StreetName { get; set; } = null!;


	[Display(Name = "Postal Code*")]
	[Required(ErrorMessage = "Please enter your Postal Code.")]
	public string PostalCode { get; set; } = null!;


	[Display(Name = "City*")]
	[Required(ErrorMessage = "Please enter your City.")]
	public string City { get; set; } = null!;


	[Display(Name = "Mobile (optional)")]
	public string? PhoneNumber { get; set; }


	[Display(Name = "Company (optional)")]
	public string? CompanyName { get; set; }


	[Display(Name = "E-mail*")]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "Please enter your E-mail.")]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to enter a valid E-mail.")]
	public string Email { get; set; } = null!;


	[Display(Name = "Password*")]
	[DataType(DataType.Password)]
	[Required(ErrorMessage = "Please enter a Password.")]
	[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You need to enter a valid Password.")]
	public string Password { get; set; } = null!;


	[Display(Name = "Confirm Password*")]
	[DataType(DataType.Password)]
	[Required(ErrorMessage = "Please confirm the Password.")]
	[Compare(nameof(Password), ErrorMessage = "The Passwords don't match.")]
	public string ConfirmPassword { get; set; } = null!;


	[Display(Name = "Upload Profile Image (optional)")]
	public string? ProfileImage { get; set; }

	[Required(ErrorMessage = "Please Accept the Terms.")]
	public bool AcceptsTerms { get; set; } = false;


	#region implicit operators
	
	//Standard Identity
	public static implicit operator IdentityUser(AccountRegisterViewModel viewModel)
	{
		return new IdentityUser
		{
			UserName = viewModel.Email,
			Email = viewModel.Email,
			PhoneNumber = viewModel.PhoneNumber,
		};
	}

	public static implicit operator UserProfileEntity(AccountRegisterViewModel viewModel)
	{
		return new UserProfileEntity
		{
			FirstName = viewModel.FirstName,
			LastName = viewModel.LastName,
			StreetName = viewModel.StreetName,
			PostalCode = viewModel.PostalCode,
			City = viewModel.City,
			CompanyName = viewModel.CompanyName,
			ProfileImage = viewModel.ProfileImage
		};
	}


	//Custom Identity
	//public static implicit operator CustomIdentityUser(AccountRegisterViewModel viewModel)
	//{
	//	return new CustomIdentityUser
	//	{
	//		UserName = viewModel.Email,

	//		FirstName = viewModel.FirstName,
	//		LastName = viewModel.LastName,
	//		Email = viewModel.Email,
	//		PhoneNumber = viewModel.PhoneNumber,
	//	};
	//}


	//Vanilla
	public static implicit operator UserEntity(AccountRegisterViewModel viewModel)
	{
		var userEntity = new UserEntity { Email = viewModel.Email };
		userEntity.GenerateSecurePassword(viewModel.Password);
		return userEntity;
	}
	
	public static implicit operator ProfileEntity(AccountRegisterViewModel viewModel)
	{
		return new ProfileEntity
		{
			FirstName = viewModel.FirstName,
			LastName = viewModel.LastName,
			StreetName = viewModel.StreetName,
			PostalCode = viewModel.PostalCode,
			City = viewModel.City,
			PhoneNumber = viewModel.PhoneNumber,
			CompanyName = viewModel.CompanyName,
			ProfileImage = viewModel.ProfileImage
		};
	}
	
	#endregion
}

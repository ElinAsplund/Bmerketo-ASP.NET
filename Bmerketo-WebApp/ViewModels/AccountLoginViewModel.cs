using Bmerketo_WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class AccountLoginViewModel
{
	[Display(Name = "E-mail*")]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "Please enter your E-mail.")]
	public string Email { get; set; } = null!;


	[Display(Name = "Password*")]
	[DataType(DataType.Password)]
	[Required(ErrorMessage = "Please enter your Password.")]
	public string Password { get; set; } = null!;

	public bool KeepLoggedIn { get; set; } = false;

	#region implicit operators

	//public static implicit operator UserEntity(AccountLoginViewModel accountLoginViewModel)
	//{
	//	var userEntity = new UserEntity { Email = accountLoginViewModel.Email };
	//	userEntity.VerifySecurePassword(accountLoginViewModel.Password);
	//	return userEntity;
	//}

	#endregion
}

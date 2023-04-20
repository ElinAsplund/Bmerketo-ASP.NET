using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class ContactRegisterViewModel
{

	[Display(Name = "Name*")]
	[Required(ErrorMessage = "Please enter your name.")]
	[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a valid First Name.")]
	public string FullName { get; set; } = null!;

	[Display(Name = "E-mail*")]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "Please enter your e-mail.")]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to enter a valid E-mail.")]
	public string Email { get; set; } = null!;

	[Display(Name = "Phone Number*")]
	[Required(ErrorMessage = "Please enter your phone number.")]
	public string PhoneNumber { get; set; } = null!;

	[Display(Name = "Company (optional)")]
	public string? CompanyName { get; set; }

	[Display(Name = "Write something*")]
	[Required(ErrorMessage = "Please enter a comment.")]
	public string Comment { get; set; } = null!;

	//public bool SaveInBrowser { get; set; } = false;


	#region implicit operators
	//EXAMPLE:
	//public static implicit operator IdentityUser(AccountRegisterViewModel viewModel)
	//{
	//	return new IdentityUser
	//	{
	//		UserName = viewModel.Email,
	//		Email = viewModel.Email,
	//		PhoneNumber = viewModel.PhoneNumber,
	//	};
	//}

	#endregion
}

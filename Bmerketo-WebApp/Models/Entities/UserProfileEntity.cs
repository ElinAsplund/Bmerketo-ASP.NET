using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo_WebApp.Models.Entities;

public class UserProfileEntity
{
	//THIS IS A "COPY" OF ProfileEntity.cs

	[Key, ForeignKey("User")]
	public string UserId { get; set; } = null!;

	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string StreetName { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public string City { get; set; } = null!;

	//Optional
	public string? CompanyName { get; set; }
	public string? ProfileImage { get; set; }

	//public bool AcceptsTerms { get; set; } <-- No need? Confirms in the frontend!? (it will always "true" in db?)

	public IdentityUser User { get; set; } = null!;
}

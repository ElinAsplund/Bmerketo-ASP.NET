using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.Models.Entities;

public class ContactEntity
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string FullName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? CompanyName { get; set; }
	public string Comment { get; set; } = null!;
}

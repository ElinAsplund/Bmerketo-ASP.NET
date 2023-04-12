using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.Models.Identity;

public class CustomIdentityUser : IdentityUser
{
    //[Key, ForeignKey("User")]
    //public Guid UserId { get; set; }

    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    //public string StreetName { get; set; } = null!;

    //public string PostalCode { get; set; } = null!;

    //public string City { get; set; } = null!;

    ////Optional
    //public string? PhoneNumber { get; set; }
    //public string? CompanyName { get; set; }
    //public string? ProfileImage { get; set; }

    ////public bool AcceptsTerms { get; set; } <-- No need? Confirms in the frontend!? (it's always "true" in db.)

    //public UserEntity User { get; set; } = null!;
}

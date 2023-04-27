using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo_WebApp.Models;

public class UserModel
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    //ROLES?
    public string Role { get; set; } = null!;

    //LATER?
    //public string StreetName { get; set; } = null!;
    //public string PostalCode { get; set; } = null!;
    //public string City { get; set; } = null!;
    public string? ProfileImage { get; set; }

    #region implicit operators

    public static implicit operator UserModel(UserProfileEntity entity)
    {
        return new UserModel
        {
            Id = entity.User.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.User.Email!,
            PhoneNumber = entity.User.PhoneNumber,
            ProfileImage = entity.ProfileImage
        };
    }

    public static implicit operator UserModel(IdentityUser entity)
    {
        return new UserModel
        {
            Id = entity.Id,
            Email = entity.Email!,
            PhoneNumber = entity.PhoneNumber
        };
    }

    #endregion
}

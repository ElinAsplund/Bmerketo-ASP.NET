using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class UsersIndexViewModel
{
    [Display(Name = "Id:")]
    public string UserId { get; set; } = null!;

    [Display(Name = "Current role:")]
    public string Role { get; set; } = null!;
}

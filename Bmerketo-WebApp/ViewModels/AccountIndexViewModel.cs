using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.ViewModels;

public class AccountIndexViewModel
{
    public string? Title { get; set; }
    public UserProfileEntity UserProfile { get; set; } = null!;
    public UserModel User { get; set; } = null!;
}

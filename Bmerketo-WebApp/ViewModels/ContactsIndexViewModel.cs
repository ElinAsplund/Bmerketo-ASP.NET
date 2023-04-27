using Bmerketo_WebApp.Models;

namespace Bmerketo_WebApp.ViewModels;

public class ContactsIndexViewModel
{
    public string? Title { get; set; }
    public HeroModel ContactHero { get; set; } = null!;
    public ContactFormViewModel ContactForm { get; set; } = null!;
}

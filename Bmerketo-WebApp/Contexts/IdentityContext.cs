using Bmerketo_WebApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Contexts;

public class IdentityContext : IdentityDbContext<CustomIdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }
}
using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Contexts;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
	public IdentityContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<UserProfileEntity> UserProfiles { get; set; }
}
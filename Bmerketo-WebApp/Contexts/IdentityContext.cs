using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Bmerketo_WebApp.Contexts;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
	public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "0e720096-5c02-49ee-b5ea-d88766bd456b", Name = "admin", NormalizedName = "ADMIN" });
		builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "6ab1077a-27b8-47ac-8083-850615ea97c8", Name = "user", NormalizedName = "USER" });

		builder.Entity<AddressEntity>()
			.HasIndex(x => x.StreetName)
			.IsUnique();
	}

	public DbSet<UserProfileEntity> UserProfiles { get; set; }
	public DbSet<AddressEntity> Addresses { get; set; }
}
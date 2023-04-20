using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//modelBuilder.Entity<CategoryEntity>().HasData(
		//	new { Id = 1, Name = "new" },
		//	new { Id = 2, Name = "popular" },
		//	new { Id = 3, Name = "featured" }
		//);
	}

	public DbSet<ContactEntity> Contacts { get; set; }
	//public DbSet<UserEntity> Users { get; set; }
	//public DbSet<ProfileEntity> Profiles { get; set; }
	//public DbSet<ProductEntity> Products { get; set; }
	//public DbSet<CategoryEntity> Categories { get; set; }
	//public DbSet<ProductCategoryEntity> ProductsCategories { get; set; }
}

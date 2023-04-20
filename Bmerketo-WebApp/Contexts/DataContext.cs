using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Contexts;

public class DataContext : DbContext
{
	//PROBABLY WILL TRY TO REMOVE THIS CONTEXT!?
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CategoryEntity>().HasData(
			new { Id = 1, Name = "new" },
			new { Id = 2, Name = "popular" },
			new { Id = 3, Name = "featured" }
			//new { Id = 1, Name = "All" },
			//new { Id = 2, Name = "Bags" },
			//new { Id = 3, Name = "Dress" },
			//new { Id = 4, Name = "Decoration" },
			//new { Id = 5, Name = "Essentials" },
			//new { Id = 6, Name = "Interior" },
			//new { Id = 7, Name = "Laptop" },
			//new { Id = 8, Name = "Mobile" },
			//new { Id = 9, Name = "Beauty" },
			//new { Id = 10, Name = "Table Lamp" },
			//new { Id = 11, Name = "Light" }
		);
	}

	public DbSet<UserEntity> Users { get; set; }
	public DbSet<ProfileEntity> Profiles { get; set; }
	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<ProductCategoryEntity> ProductsCategories { get; set; }

}

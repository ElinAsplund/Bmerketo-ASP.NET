namespace Bmerketo_WebApp.Models.Entities;

public class CategoryEntity
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;
	public string? Description { get; set; }

	//public ICollection<ProductEntity> Products = new HashSet<ProductEntity>(); //Dont need?
	public ICollection<ProductCategoryEntity> ProductCategories = new HashSet<ProductCategoryEntity>();
}

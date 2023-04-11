namespace Bmerketo_WebApp.Models;

public class ProductModel
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public decimal Price { get; set; } = 0;
	public string? LgImgUrl { get; set; } = null!;
	public string? SmImgUrl { get; set; } = null!;

	public IEnumerable<string>? Categories;
}

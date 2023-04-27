using Bmerketo_WebApp.Models;

namespace Bmerketo_WebApp.ViewModels;

public class ProductListViewModel
{
	public string? Title { get; set; }
	public IEnumerable<ProductModel> Products { get; set; } = null!;
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;


[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategoryEntity
{
	//[Key, ForeignKey("Product")]
	public int ProductId { get; set; }

	//[Key, ForeignKey("Category")]
	public int CategoryId { get; set; }

	public ProductEntity Product { get; set; } = null!;
	public CategoryEntity Category { get; set; } = null!;
}

using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Services;

public class CategoryService
{
    private readonly ProductContext _productContext;

    public CategoryService(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync()
    {
        var categories = await _productContext.Categories.ToListAsync();

        return categories!;
    }
}

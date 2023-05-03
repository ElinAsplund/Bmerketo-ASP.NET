using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models;
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
    
    public async Task<List<ProductCategoryModel>> GetProductCategoriesAsync(ProductModel product)
    {
        var productCategoryModels = new List<ProductCategoryModel>();
        var productCategories = await _productContext.ProductsCategories.Include(x => x.Category).Where(x => x.ProductId == product.Id).ToListAsync();

        foreach (var item in productCategories)
        {
            if (item.ProductId == product.Id)
            {
                var productCategoryModel = new ProductCategoryModel
                {
                    CategoryId = item.Category.Id,
                    CategoryName = item.Category.Name,
                    ProductId = product.Id
                };

                productCategoryModels.Add(productCategoryModel);
            }

        }

        return productCategoryModels;
    }
}

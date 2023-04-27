using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Services;

public class CheckboxOptionService
{
    public readonly CategoryService _categoryService;

    public CheckboxOptionService(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<List<CheckboxOptionModel>> PopulateCheckBoxesAsync()
    {
        var checkboxes = new List<CheckboxOptionModel>();
        var categories = await _categoryService.GetCategoriesAsync();

        foreach (var category in categories)
        {
            var checkbox = new CheckboxOptionModel();

            if (category == categories.First()) { checkbox.IsChecked = true; }

            checkbox.Description = category.Name;
            checkbox.Value = category.Id;

            checkboxes.Add(checkbox);
        }

        return checkboxes;
    }
}

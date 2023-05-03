using Bmerketo_WebApp.ViewModels;

namespace Bmerketo_WebApp.Models;

public class ProductCategoryModel
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;


    #region implicit operators

    //public static implicit operator ProductModel(ProductCategoryModel model)
    //{
    //    return new ProductModel
    //    {
            
    //    };
    //}

    #endregion
}

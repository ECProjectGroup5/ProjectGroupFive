using Infrastructure.Models;

namespace RikaApp.ViewModels;

public class ProductsViewModel
{
    public string Title { get; set; } = "Products";
    public ProductModel? Product { get; set; }
    public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
}
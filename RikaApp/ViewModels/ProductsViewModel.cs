using Infrastructure.Models;
using RikaApp.Models;

namespace RikaApp.ViewModels;

public class ProductsViewModel
{
    public ProductsViewModel()
    {
        Creation = new ProductCreationModel();
    }
    public string Title { get; set; } = "Products";
    public ProductModel? Product { get; set; }
    public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();

    public ProductCreationModel? Creation { get; set; }
}
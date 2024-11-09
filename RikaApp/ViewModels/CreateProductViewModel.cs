

using RikaApp.Models;

namespace RikaApp.ViewModels;

public class CreateProductViewModel
{
  
    public string Title { get; set; } = "Create Product";
    public ProductCreationModel? Product { get; set; }
    

}

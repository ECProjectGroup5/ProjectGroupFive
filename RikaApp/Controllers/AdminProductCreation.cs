using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RikaApp.ViewModels;
using System.Reflection;
using System.Text;

namespace RikaApp.Controllers;

public class AdminProductCreation(HttpClient client) : Controller
{

    private readonly HttpClient _client = client;

    public IActionResult Index()
    {
        {
            var viewModel = new ProductsViewModel();
            return View(viewModel);
        }
    }

    [HttpPost]
    public async Task<IActionResult>CreateProduct(ProductsViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            viewModel.Creation.SizeNames ??= new List<string>();
            viewModel.Creation.ColorNames ??= new List<string>();
            try
            {
                if (viewModel.Creation != null)
                {
                    var body = JsonConvert.SerializeObject(viewModel.Creation);
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    var response = await _client.PostAsync("http://localhost:7189/api/CreateAPI", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "AdminProductPortal");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create the product. Please try again.");
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
                
        }
        return RedirectToAction("Index");
    } 

}

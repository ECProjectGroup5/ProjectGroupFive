using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RikaApp.ViewModels;

namespace RikaApp.Controllers;

public class ProductsController(HttpClient client) : Controller
{
    private readonly HttpClient _client = client;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var viewModel = new ProductsViewModel();
            var content = await _client.GetStringAsync("http://localhost:7189/api/GetAllAPI");

            viewModel.Products = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(content)!;

            return View(viewModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return View();
    }

    [HttpGet]
    public IActionResult Details(Guid articleNumber)
    {
        return View();
    }
}
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RikaApp.ViewModels;
using System.Text.Json.Nodes;
using System.Text;

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
    public async Task<IActionResult> Details(Guid articleNumber)
    {
        try
        {
            var viewModel = new ProductsViewModel();
            var productRequest = new { ArticleNumber = articleNumber };

            var body = JsonConvert.SerializeObject(productRequest);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            if (body != null)
            {
                var response = await _client.PostAsync("http://localhost:7189/api/GetOneByArticlenumberrAPI", content);

                if (response != null && response.IsSuccessStatusCode)
                {
                    var rawProduct = await response.Content.ReadAsStringAsync();
                    var unpackedProduct = JsonConvert.DeserializeObject<ProductModel>(rawProduct);

                    viewModel.Product = unpackedProduct;
                    return View(viewModel);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return View();
    }
}
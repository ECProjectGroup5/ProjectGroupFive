using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RikaApp.ViewModels;
using System.Text;

namespace RikaApp.Controllers;

public class AdminSingleProductController(HttpClient client) : Controller
{
    private readonly HttpClient _client = client;

    [HttpGet]
    public async Task<IActionResult> Details(Guid articleNumber)
    {
        try
        {
            
            var viewModel = new ProductsViewModel();
            var productRequest = new { ArticleNumber = articleNumber };

            var body = JsonConvert.SerializeObject(productRequest);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

           
                var response = await _client.PostAsync("http://localhost:7189/api/GetOneByArticlenumberrAPI", content);

                if (response != null && response.IsSuccessStatusCode)
                {
                    var rawProduct = await response.Content.ReadAsStringAsync();
                    var unpackedProduct = JsonConvert.DeserializeObject<ProductModel>(rawProduct);

                    viewModel.Product = unpackedProduct;
                    return View(viewModel);
                }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return View();
    }


    [HttpPost]
public async Task<IActionResult> UpdateProduct(ProductsViewModel viewModel)
{
    if (ModelState.IsValid)
    {
        try
        {
            if (viewModel.Product != null)
            {
               
                var body = JsonConvert.SerializeObject(viewModel.Product);
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                
                var response = await _client.PutAsync("http://localhost:7189/api/UpdateAPI", content);

                if (response != null && response.IsSuccessStatusCode)
                {
                    
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var updatedProduct = JsonConvert.DeserializeObject<ProductModel>(stringResponse);

                    if (updatedProduct != null)
                    {
                       
                        viewModel.Product = updatedProduct;

                       
                        return View("Details", viewModel);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to deserialize updated product details. Please try again.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update the product. Please try again.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Product information is missing. Please try again.");
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex.Message);
            ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
        }
    }

   
    if (viewModel.Product == null)
    {
        viewModel.Product = new ProductModel(); 
    }

    return View("Details", viewModel);
}

    [HttpPost]

    public async Task <IActionResult> DeleteProduct(Guid articlenumber) 
    { 
     try
        {
            var viewModel = new ProductsViewModel();
            var productRequest = new { ArticleNumber = articlenumber };

            var body = JsonConvert.SerializeObject(productRequest);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            if (body != null)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("http://localhost:7189/api/DeleteAPI"),
                    Content = content
                };

                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminProductPortal");
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

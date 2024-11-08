﻿using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RikaApp.ViewModels;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace RikaApp.Controllers;

public class AdminProductPortalController : Controller
{
    private readonly HttpClient _client;
    public AdminProductPortalController(HttpClient httpClient)
    {
        _client = httpClient; 
    }

    [HttpGet]
    public async Task <IActionResult> Index()
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

}

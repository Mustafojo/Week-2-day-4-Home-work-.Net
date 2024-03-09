using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productcontroller;
    public ProductController()
    {
        _productcontroller = new ProductService();
    }
    [HttpPost("Add - Product")]
    public async void AddProductsAsync (Products products)
    {
        await _productcontroller.AddProductAsync(products);
    }
    [HttpGet("Get - Products")]
    public async Task<List<Products>> GetProductsAsync()
    {
        return await _productcontroller.GetProductsAsync();
    }
    [HttpPut("Update - Product")]
    public async void UpdateProductsAcync(Products products)
    {
        await _productcontroller.UpdateProductsAcync(products);
    }
    [HttpDelete("Delete - Product")]
    public async void DeleteProduct(int id)
    {
        await _productcontroller.DeleteProduct(id);
    }
  
}
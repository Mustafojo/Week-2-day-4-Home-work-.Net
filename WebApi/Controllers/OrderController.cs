using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrdersService _ordercontroller;
    public OrderController()
    {
        _ordercontroller = new OrdersService();
    }
    [HttpPost("Add - Order")]
    public async void AddOrderAcync(Orders orders)
    {
        await _ordercontroller.AddOrderAcync(orders);
    }
    [HttpGet("Get - Orders")]
    public async Task<List<Orders>> GetOrdersAcync()
    {
        return await _ordercontroller.GetOrdersAsync();
    }

    [HttpPut("Update - Order")]
    public async void UpdateOrderAcync(Orders orders)
    {
        await _ordercontroller.UpdateOrderAcync(orders);
    }
    [HttpDelete("Delete - Order")]
    public async void DeleteOrder(int id)
    {
        await _ordercontroller.DeleteOrder(id);
    }
    [HttpGet("Get Orders and OrderDetails")]
    public async Task<List<OrderProduct>> GetOrdersByOrderDetails()
    {
        return await _ordercontroller.GetOrdersByOrderDetails();
    }
    [HttpGet("Get Orders By Quantity")]
    public async Task<List<Orders>> GetOrdersByQuantity(decimal amount)
    {
        return await _ordercontroller.GetOrdersByQuantity(amount);
    }

}
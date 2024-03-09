using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly OrderDetailService _orderdetailcontroller;
    public OrderDetailController()
    {
        _orderdetailcontroller = new OrderDetailService();
    }
    [HttpPost("Add - OrderDetail")]
    public async void AddOrderDetailsAcync(OrderDetails orderDetails)
    {
        await _orderdetailcontroller.AddOrderDetailsAcync(orderDetails);
    }
    [HttpGet("Get - OrderDetails")]
    public async Task<List<OrderDetails>> GetOrderDetailsAcync()
    {
        return await _orderdetailcontroller.GetOrderDetailsAsync();
    }

    [HttpPut("Update - OrderDetail")]
    public async void UpdateOrderDetailAcync(OrderDetails orderdetails)
    {
        await _orderdetailcontroller.UpdateOrderDetailsAcync(orderdetails);
    }
    [HttpDelete("Delete - OrderDetail")]
    public async void DeleteOrderDeatail(int id)
    {
        await _orderdetailcontroller.DeleteOrderDetail(id);
    }

    [HttpGet("Get Edinits")]
    public async Task<string> GetEdinits(int productid)
    {
        return await _orderdetailcontroller.GetEdinits(productid);
    }

}
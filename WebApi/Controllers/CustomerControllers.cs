using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerControllers : ControllerBase
{
    private readonly CustomerService _customercontroller;
    public CustomerControllers()
    {
        _customercontroller = new CustomerService();
    }

    [HttpPost("Add Customer")]
    public async void AddCustomerAsync(Customers customers)
    {
        await _customercontroller.AddCustomerAsync(customers);
    }

    [HttpGet("Get Customers")]
    public async Task<List<Customers>> GetCustomersAsync()
    {
        return await _customercontroller.GetCustomersAsync();
    }

    [HttpPut("Update Customer")]
    public async Task<Customers> UpdateCustomer(Customers customers)
    {
        await _customercontroller.UpdateCustomerAcync(customers);
        return customers;
    }

    [HttpDelete("Delete Customer")]
    public async void DeleteCustomer(int id)
    {
        await _customercontroller.DeleteCustomer(id);
    }

    [HttpGet("Get Customers By OrderedDate")]
    public async Task<List<Customers>> GetCustomersByOrderDate(DateTime start,DateTime end)
    {
        return await _customercontroller.GetCustomersByOrderDate(start,end);
    }

    [HttpGet("Get Customer Avg")]
    public async Task<List<Customers>> GetCustomerAvg()
    {
        return await _customercontroller.GetCustomerAvg();
    }

}
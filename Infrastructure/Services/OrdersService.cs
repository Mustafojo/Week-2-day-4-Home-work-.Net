using Dapper;
using Domain.Models;
using Infrastructure.DataContex;

namespace Infrastructure.Services;

public class OrdersService
{
    private readonly DapperContext _contex;
    public OrdersService()
    {
        _contex = new DapperContext();
    }

    public async Task<List<Orders>> GetOrdersAsync()
    {
        var sql = "select * from Orders";
        var cat = await _contex.Connection().QueryAsync<Orders>(sql);
        return cat.ToList();
    }
    public async Task<Orders> AddOrderAcync(Orders orders)
    {
        var sql = "insert into Orders (customerid,data,amount) values (@customerid,@data,@amount)";
        await _contex.Connection().ExecuteAsync(sql , orders);
        return orders;
    }

    public async Task<Orders> UpdateOrderAcync(Orders orders)
    {
        var sql = "update Orders set customerid = @customerid,data = @data,amount = @amount where orderid = @orderid";
       await  _contex.Connection().ExecuteAsync(sql, orders);
       return orders;
    }
    
    public async Task<string> DeleteOrder(int id)
    {
        var sql = "delete from Orders where orderid = @orderid";
        await _contex.Connection().ExecuteAsync(sql,new { Id = id});
        return "Successfully";
    }

    public async Task<List<OrderProduct>> GetOrdersByOrderDetails()
    {
        var sql = @"select p.ProductId,p.ProductName,od.Quantity,o.Amount
                    from OrderDetails as od
                    join Orders as o on o.OrderId = od.OrderId
                    join Products as p on p.ProductId = od.ProductId";
        var result = await _contex.Connection().QueryAsync<OrderProduct>(sql);
        return result.ToList();
    }

    public async Task<List<Orders>> GetOrdersByQuantity(decimal amount)
    {
        var sql = @"select * from Orders as o
                   where o.amount >= @amount";
        var result = await _contex.Connection().QueryAsync<Orders>(sql, new {Amount = amount});
        return result.ToList();
    }
    
}

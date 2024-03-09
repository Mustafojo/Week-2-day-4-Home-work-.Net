using Dapper;
using Domain.Models;
using Infrastructure.DataContex;

namespace Infrastructure.Services;

public class OrderDetailService
{
    private readonly DapperContext _contex;
    public OrderDetailService()
    {
        _contex = new DapperContext();
    }

    public async Task<List<OrderDetails>> GetOrderDetailsAsync()
    {
        var sql = "select * from OrderDetails";
        var cat = await _contex.Connection().QueryAsync<OrderDetails>(sql);
        return cat.ToList();
    }
    public async Task<OrderDetails> AddOrderDetailsAcync(OrderDetails orderDetails)
    {
        var sql = "insert into OrderDetails (orderid,productid,quantity,unitprice) values (@orderid,@productid,@quantity,@unitprice)";
        await _contex.Connection().ExecuteAsync(sql , orderDetails);
        return orderDetails;
    }

    public async Task<OrderDetails> UpdateOrderDetailsAcync(OrderDetails orderdetails)
    {
        var sql = "update OrderDetails set orderid = @orderid,productid = @productid,quantity = quantity,unitprice = unitprice where orderdetailid = @orderdetailid";
       await  _contex.Connection().ExecuteAsync(sql, orderdetails);
       return orderdetails;
    }
    
    public async Task<string> DeleteOrderDetail(int id)
    {
        var sql = "delete from OrderDetails where orderdetailid = @orderdetailid";
        await  _contex.Connection().ExecuteAsync(sql,new { Id = id});
        return "Successfully";
    }

    public async Task<string> GetEdinits(int productid)
    {
        var sql = @"select Sum(ob.Quantity) from OrderDetails as ob
                    where ProductId = @ProductId";
        var result = await _contex.Connection().QueryAsync<int>(sql,new {ProductId = productid});
        return result.ToString();

    }
    
}

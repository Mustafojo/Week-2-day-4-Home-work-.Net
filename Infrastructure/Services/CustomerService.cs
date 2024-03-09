using Dapper;
using Domain.Models;
using Infrastructure.DataContex;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly DapperContext _contex;
    public CustomerService()
    {
        _contex = new DapperContext();
    }

    public async Task<List<Customers>> GetCustomersAsync()
    {
        var sql = "select * from Customers";
        var cat = await _contex.Connection().QueryAsync<Customers>(sql);
        return cat.ToList();
    }
    public async Task<Customers> AddCustomerAsync(Customers customers)
    {
        var sql = "insert into Customers (fullname,email,address) values (@fullname,@email,@address)";
        await _contex.Connection().ExecuteAsync(sql , customers);
        return customers;
    }

    public async Task<Customers> UpdateCustomerAcync(Customers customers)
    {
        var sql = "update Customers set fullname = @fullname,email = @email,address = @address where customerid = @customerid";
       await  _contex.Connection().ExecuteAsync(sql, customers);
       return customers;
    }
    
    public async Task<string> DeleteCustomer(int id)
    {
        var sql = "delete from Customers where customerid = @customerid";
        await _contex.Connection().ExecuteAsync(sql,new { Id = id});
        return "Successfully";
    }

    public async Task<List<Customers>> GetCustomersByOrderDate(DateTime start,DateTime end)
    {
        var sql = @"select c.CusomerId,c.FullName,c.Address,o.Data,o.Amount
                    from Orders as o
                    join Customers as c on c.CustomerId = o.CustomerId
                    where o.Data between @start and @end";
        var result = await _contex.Connection().QueryAsync<Customers>(sql, new {Start = start,End = end});
        return result.ToList();
    }

    public async Task<List<Customers>> GetCustomerAvg()
    {
        var sql = @"select c.CustomerId,c.FullName,c.Email,c.Address,Avg(o.Amount) as Avgcustomer
                    from Orders as o
                    join Customers as c on c.CustomerId = o.CustomerId
                    group by c.CustomerId";
        var result = await _contex.Connection().QueryAsync<Customers>(sql);
        return result.ToList();
    }

    
}

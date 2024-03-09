using Domain.Models;
using Dapper;
using Npgsql;
using Infrastructure.DataContex;
using System.Security.Cryptography.X509Certificates;
namespace Infrastructure.Services;

public class ProductService
{
     private readonly DapperContext _contex;
    public ProductService()
    {
        _contex = new DapperContext();
    }

     public async Task<List<Products>> GetProductsAsync()
    {
        var sql = "select * from Products";
        var cat = await _contex.Connection().QueryAsync<Products>(sql);
        return cat.ToList();
    }
    public async Task<Products> AddProductAsync(Products products)
    {
        var sql = "insert into Products (productname,price,stockquantity) values (@productname,@price,@stockquantity)";
        await _contex.Connection().ExecuteAsync(sql , products);
        return products;
    }

    public async Task<Products> UpdateProductsAcync(Products products)
    {
        var sql = "update Products set productname = @productname,price = @price,stockquantity = @stockquantity where productid = @productid";
        await _contex.Connection().ExecuteAsync(sql , products);
        return products;
    }
    
    public async Task<string> DeleteProduct(int id)
    {
        var sql = "delete from Departments where productid = @productid";
        await _contex.Connection().ExecuteAsync(sql, new {Id = id});
        return "Successfully";
    }
}

using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using obada.Interface;
using obada.Models;

namespace obada.Repository;

public class dapperOrderRepository:IOrderRepository
{
    private SqlConnection connection;
    readonly private IConfiguration  _configuration;

    public dapperOrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        connection  = new SqlConnection(_configuration.GetConnectionString("DefultConnection"));
    }

    public async Task<int> Add(Order order)
    {
        var orders = await connection.ExecuteAsync(
            "INSERT INTO Orders(CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia," +
            "Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)VALUES(@CustomerId,@EmployeeID" +
            ",@OrderDate,@RequiredDate,@ShippedDate,@ShipVia,@Freight,@ShipName,@ShipAddress,@ShipCity" +
            ",@ShipRegion,@ShipPostalCode,@ShipCountry)",order);
        return (orders);
        
    }

    public async Task<Order> find(int orderId)
    {
        var orders = await connection.QuerySingleAsync<Order>("select * from orders where OrderID =@Id",new {Id =orderId});
        Console.WriteLine(orders);
        return (orders);
    }

    public Order find(Order order)
    {
        throw new NotImplementedException();
    }

    public void Delete(Order order)
    {
        throw new NotImplementedException();
       // var result = await connection.ExecuteAsync("delete orders where id");
    }

    public void Update(Order order)
    {
        throw new NotImplementedException();
    }
}
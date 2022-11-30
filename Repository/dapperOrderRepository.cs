using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using obada.Interface;
using obada.Models;

namespace obada.Repository;

public class dapperOrderRepository:IOrderRepository
{
    private SqlConnection connection;
    readonly private IConfiguration  _configuration;

    public dapperOrderRepository()
    {
       // _configuration = configuration;
        connection  = new SqlConnection("Server =.\\SQLEXPRESS;Database=Northwind;Trusted_Connection=true; TrustServerCertificate=True; ");
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

        return (orders);
    }

    public Order find(Order order)
    {
        // string selectQuery = @"SELECT * FROM [dbo].[orders] WHERE OrderId = @OrderId";
        //
        // var result = connection.Query(selectQuery, new
        // {
        //     order.OrderId
        // });
        throw new NotImplementedException();
    }

    public int Delete(Order order)
    {
        string deleteQuery = @"DELETE TOP 10 FROM [dbo].[orders] ";

        var result = connection.Execute(deleteQuery, new
        {
            order.OrderId
        });
        return result;
        // var result = await connection.ExecuteAsync("delete orders where id");
    }

    public int Delete()
    {
        string deleteQuery = @"DELETE TOP (1) FROM [dbo].[orders] ";

        var result = connection.Execute(deleteQuery);
        return result;    }

    public async Task<int> Update(Order order)
    {

        int orders =  connection.Execute("UPDATE [dbo].[Orders]SET [CustomerID] =@CustomerId ,[EmployeeID] =@EmployeeID ,[OrderDate] =@OrderDate " +
                                         ",[RequiredDate] =@RequiredDate,[ShippedDate] =@ShippedDate,[ShipVia] =@ShipVia,[Freight] =@Freight ,[ShipName] =@ShipName ,[ShipAddress] =@ShipAddress " +
                                         ",[ShipCity] =@ShipCity,[ShipRegion] =@ShipRegion ,[ShipPostalCode] =@ShipPostalCode  ,[ShipCountry] =@ShipCountry" +
                                         " WHERE OrderID =@OrderID",order);
        return (order.OrderId);
    }

    public void joinComplex()
    {
        throw new NotImplementedException();
    }
}
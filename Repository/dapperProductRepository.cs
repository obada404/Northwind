using Dapper;
using Microsoft.Data.SqlClient;
using obada.Interface;
using obada.Models;

namespace obada.Repository;

public class dapperProductRepository:IproductRepository
{
    private SqlConnection connection;
    readonly private IConfiguration  _configuration;

    public dapperProductRepository()
    {
        // _configuration = configuration;
        connection  = new SqlConnection("Server =.\\SQLEXPRESS;Database=Northwind;Trusted_Connection=true; TrustServerCertificate=True; ");
    }
    public int Add(Product product)
    {
        throw new NotImplementedException();
    }

    public Product find(int productId)
    {
        throw new NotImplementedException();
    }

    public Product find(Product product)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product product)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }

    public dynamic complexJoin(int productId)
    {
       
        
            var result =  connection.Query("SELECT TOP (1000) [ProductID],[ProductName],Products.[SupplierID]," +
                                           "Suppliers.SupplierID,Products.[CategoryID],Categories.CategoryID,[QuantityPerUnit]" +
                                           ",[UnitPrice],[UnitsInStock],Suppliers.CompanyName,Suppliers.ContactName,Suppliers.Country" +
                                           ",Suppliers.Phone,Categories.CategoryName,Categories.Description" +
                                           " FROM [Northwind].[dbo].[Products]" +
                                           " inner JOIN Suppliers  on Suppliers.SupplierID =Products.SupplierID" +
                                           " inner JOIN Categories on Categories.CategoryID =Products.CategoryID" +
                                           " where ProductID =@ID",new {ID =productId});
            return (result.ToList().Last());
        
        
    }
}
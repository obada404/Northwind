using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using obada.DTO;
using obada.Models;

namespace obada.Controllers;

public class HomeController : Controller
{
    readonly private IConfiguration  _configuration;
         private SqlConnection connection;
    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
        connection  = new SqlConnection(_configuration.GetConnectionString("DefultConnection"));
    }

    [HttpGet]
    [Route("/index/{Query}")]
    public async Task<ActionResult<List<Order>>>  getindex(String Query)
    {
        
        var orders = await connection.QueryAsync(Query);
        return Ok(orders);
    }
    
 
}

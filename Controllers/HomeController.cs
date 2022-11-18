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
    readonly private NorthwindContext  _context;
    readonly private IConfiguration  _configuration;

    public HomeController(NorthwindContext context,IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet]
    [Route("/index")]
    public async Task<ActionResult<List<Order>>>  getindex()
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefultConnection"));
        var orders = await connection.QueryAsync("select * from orders");
        return Ok(orders);
    }
    
 
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using obada.DTO;
using obada.Models;
using obada.Service;

namespace obada.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet]
    [Route("/order/{orderId}")]
    public Task<Order> GetOrder(int orderId)
    {
        return _orderService.FindOrder(orderId);
    }
    [HttpPost]
    [Route("/order")]
    public async Task<int> GetOrder([FromBody] orderRequestEnv<orderRequest> req )
    {
        return  await _orderService.addOrder(req.order);
    }
    [HttpPut]
    [Route("/order")]
    public async Task<Task<int>> updateOrder([FromBody] orderRequestEnv<orderRequest> req )
    {
        
        return   _orderService.updateOrder(req.order);
    }
    [HttpDelete]
    [Route("/order")]
    public int deleteOrder([FromBody] orderRequestEnv<orderRequest> req )
    {
       return _orderService.deleteorder(req.order);
    }
}
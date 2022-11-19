using Microsoft.AspNetCore.Mvc;
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
}
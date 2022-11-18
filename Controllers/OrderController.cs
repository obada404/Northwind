using Microsoft.AspNetCore.Mvc;
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
    public Order GetOrder(int orderId)
    {
        return _orderService.FindOrder(orderId);
    }
}
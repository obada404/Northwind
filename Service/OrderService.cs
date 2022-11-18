using obada.DTO;
using obada.Interface;
using obada.Models;

namespace obada.Service;
public interface IOrderService
{
   
    Order addOrder(orderRequest order);
    Order findOrder(orderRequest order);
    Order FindOrder(int orderId);
    bool updateOrder(orderRequest order);
    
}
public class OrderService:IOrderService
{
    private readonly IOrderRepository _orderService;
    public OrderService(IOrderRepository orderService)
    {
        _orderService = orderService;
    }
    public Order addOrder(orderRequest order)
    {
        Order tmpOrder = new Order();
       return _orderService.Add(tmpOrder);

    }

    public Order findOrder(orderRequest order)
    {
        throw new NotImplementedException();
    }

    public Order FindOrder(int orderId)
    {
      return  _orderService.find(orderId);
    }

    public bool updateOrder(orderRequest order)
    {
        throw new NotImplementedException();
    }
}
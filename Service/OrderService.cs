using obada.DTO;
using obada.Interface;
using obada.Models;

namespace obada.Service;
public interface IOrderService
{
   
    Task<int> addOrder(orderRequest order);
    Order findOrder(orderRequest order);
    Task<Order> FindOrder(int orderId);
    bool updateOrder(orderRequest order);
    
}
public class OrderService:IOrderService
{
    private readonly IOrderRepository _OrderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _OrderRepository = orderRepository;
    }
    public async Task<int> addOrder(orderRequest order)
    {
        Order tmpOrder = new Order(order);
       return  await _OrderRepository.Add(tmpOrder);
    }

    public Order findOrder(orderRequest order)
    {
        throw new NotImplementedException();
    }

    public Task<Order> FindOrder(int orderId)
    {
      return  _OrderRepository.find(orderId);
    }

    public bool updateOrder(orderRequest order)
    {
        throw new NotImplementedException();
    }
}
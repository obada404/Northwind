using Microsoft.EntityFrameworkCore.ChangeTracking;
using obada.DTO;
using obada.Interface;
using obada.Models;
using obada.Service;

namespace obada.Service;
public interface IOrderService
{
   
    Task<int> addOrder(orderRequest order);
    Order findOrder(orderRequest order);
    Task<Order> FindOrder(int orderId);
    Task<int> updateOrder(orderRequest order);
    int deleteorder(orderRequest orderRequest);
    int deleteorder();

    void joincomplex();

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

    public Task<int> updateOrder(orderRequest order)
    {
        Order tmpOrder = new Order(order);
        return  _OrderRepository.Update(tmpOrder);
    }

    public int deleteorder(orderRequest orderRequest)
    {
        Order tmpOrder = new Order(orderRequest);
       return _OrderRepository.Delete(tmpOrder);
    }
    public int deleteorder()
    {
        return _OrderRepository.Delete();
    }

    public void joincomplex()
    {
        _OrderRepository.joinComplex();
    }
}
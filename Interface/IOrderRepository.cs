using obada.Models;

namespace obada.Interface;

public interface IOrderRepository
{
    public Task<int> Add(Order order);
    public Task<Order> find(int orderId);
    public Order find(Order order);
    public void Delete(Order  order);
    public void Update(Order order);
    
}
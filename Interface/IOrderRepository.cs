using obada.Models;

namespace obada.Interface;

public interface IOrderRepository
{
    public Order Add(Order order);
    public Order find(int orderId);
    public Order find(Order order);
    public void Delete(Order  order);
    public void Update(Order order);
    
}
using Microsoft.EntityFrameworkCore.ChangeTracking;
using obada.Interface;
using obada.Models;

namespace obada.Repository;

public class EfOrderRepository:IOrderRepository
{
    private readonly NorthwindContext _context;
    public EfOrderRepository( NorthwindContext context)
    {
        _context = context;
    }
    public async Task<int> Add(Order order)
    {
       _context.Orders.Add(order);
        _context.SaveChanges();
        return order.OrderId;
    }

    public async Task<Order> find(int orderId)
    {
       return _context.Orders.FirstOrDefault(x=> x.OrderId == orderId);
    }

    public Order find(Order order)
    {
        return _context.Orders.FirstOrDefault(x=> x.OrderId == order.OrderId);
        
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
        
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }
}
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
         await _context.SaveChangesAsync();
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

    public int Delete(Order order)
    {
      var boo= _context.Orders.Remove(order).Entity.OrderId;
       _context.SaveChanges();
       return boo;
    }

    public int Delete()
    {
        var tmp= _context.Orders.FirstOrDefault();
        if(tmp != null)
        {
            _context.Orders.Remove(tmp);
           _context.SaveChangesAsync();
            return 1;
        }

        return 0;
    }

    public async Task<int> Update(Order order)
    {
        var boo = _context.Orders.FirstOrDefault(x=> x.OrderId == order.OrderId);
        _context.Orders.Remove(boo);
        _context.Add(order);
        _context.SaveChanges();
        return order.OrderId;
    }

    public void joinComplex()
    {
        throw new NotImplementedException();
    }
}
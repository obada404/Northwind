using Microsoft.EntityFrameworkCore.ChangeTracking;
using obada.Models;

namespace obada.Interface;

public interface IOrderRepository
{
    public Task<int> Add(Order order);
    public Task<Order> find(int orderId);
    public Order find(Order order);
    public int Delete(Order order);
    public int Delete();
    public Task<int> Update(Order order);

    void joinComplex();
    Task<Order> find();
}
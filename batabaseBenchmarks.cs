using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using obada.DTO;
using obada.Models;
using obada.Repository;
using obada.Service;

namespace obada;
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[InProcessAttribute]
public class batabaseBenchmarks
{
  

    private static DateTime now = DateTime.Now;
    private static readonly productService _productServiceEF = new productService(new EfProductRepository(new NorthwindContext()));
    private static readonly productService _productServicedapper = new productService(new dapperProductRepository());
    private static readonly OrderService _orderServiceEF = new OrderService(new EfOrderRepository(new NorthwindContext()));
    private static OrderService  _orderServicedapper = new OrderService(new dapperOrderRepository());
    orderRequest tmp = new orderRequest (32543,"VINET", 5, now, now, now, 
        3, 323800);
    orderRequest tmp2 = new orderRequest (10291,"VINET", 5, now, now, now, 
        3, 323800);
    
    [Benchmark]
    public void productjoinComplexdapper()
    {
     
        _productServicedapper.joinComplex(1);

    }
    [Benchmark]
    public void productjoinComplexEF()
    {
       
        _productServiceEF.joinComplex(1);

    }
    [Benchmark]
    public void addOrderUseDapper()
    {
     
        _orderServicedapper.addOrder(tmp);
    }
    [Benchmark]
    public void addOrderUseEF()
    {
       
        _orderServiceEF.addOrder(tmp);
    }
    [Benchmark]
    public void findOrderUseDapper()
    {
      
        _orderServicedapper.FindOrder(tmp2.OrderId);
    }
    [Benchmark]
    public void findOrderUseEF()
    {
        
        _orderServiceEF.FindOrder(tmp2.OrderId);
    }
    [Benchmark]
    public void deleteorderUseDapper()
    {
      
        _orderServicedapper.deleteorder();
    }
    [Benchmark]
    public void deleteorderUseEF()
    {
       
        _orderServiceEF.deleteorder();
    }
}
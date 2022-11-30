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
public class DatabaseBenchmark
{
  

    private static DateTime now = DateTime.Now;
    private static readonly productService _productServiceEF = new productService(new EfProductRepository(new NorthwindContext()));
    private static readonly productService _productServicedapper = new productService(new dapperProductRepository());
    private static readonly OrderService _orderServiceEF = new OrderService(new EfOrderRepository(new NorthwindContext()));
    private static OrderService  _orderServicedapper = new OrderService(new dapperOrderRepository());
    
    orderRequest tmp2 = new orderRequest (43234,"VINET", 5, now, now, now, 
        3, 323800);
    Random random = new Random();
    [Benchmark]
    public void productjoinComplexdapper()
    {
        var random = new Random();
        var rNum = random.Next(1, 70);
        _productServicedapper.joinComplex(rNum);

    }
    [Benchmark]
    public void productjoinComplexEF()
    {
        var rNum = random.Next(1, 70);
        _productServiceEF.joinComplex(rNum);

    }
    [Benchmark]
    public void addOrderUseDapper()
    {
        var rNum = random.Next(5000, 10000);
        orderRequest tmp = new orderRequest (rNum,"VINET", 5, now, now, now, 
            3, 323800);     
        _orderServicedapper.addOrder(tmp);
    }
    [Benchmark]
    public void addOrderUseEF()
    {
      
         
        _orderServiceEF.addOrder(tmp2);
    }
    [Benchmark]
    public void findOrderUseDapper()
    {
      
        _orderServicedapper.findOrder();
    }
    [Benchmark]
    public void findOrderUseEF()
    {
        
        _orderServiceEF.findOrder();
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
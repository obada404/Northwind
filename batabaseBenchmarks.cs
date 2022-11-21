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
public class batabaseBenchmarks
{
    private static DateTime now = DateTime.Now;
    private static readonly OrderService _orderServicedapper = new OrderService(new dapperOrderRepository(new ConfigurationManager()));
    private static readonly OrderService _orderServiceEF = new OrderService(new EfOrderRepository(new NorthwindContext()));

    private orderRequest tmp = new orderRequest (10248,"VINET", 5, now, now, now, 
        3, 323800);
    
    [Benchmark(Baseline = true)]
    public void addOrderUseDapper()
    {
        _orderServicedapper.addOrder(tmp);
    }
    [Benchmark]
    public void addOrderUseEF()
    {
        _orderServiceEF.addOrder(tmp);
    }
}
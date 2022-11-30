 
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using obada;
using obada.DTO;
using obada.Interface;
using obada.Models;
using obada.Repository;
using obada.Service;

//
// var builder = WebApplication.CreateBuilder(args);
// // builder.Services.AddDbContext<MvcMovieContext>(options =>
// //     options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));
// builder.Services.AddControllers();
// builder.Services.AddDbContext<NorthwindContext>();
// builder.Services.AddScoped<IproductRepository, EfProductRepository>();
// builder.Services.AddScoped<IprudectService, productService>();
// builder.Services.AddScoped<IOrderService, OrderService>();
// builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
// // builder.Services.AddScoped<IConfiguration, ConfigurationBuilder>();
//
// builder.Services.AddControllers().AddNewtonsoftJson(options =>
//     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
// );

BenchmarkRunner.Run<batabaseBenchmarks>();



//     OrderService _orderServiceEF = new OrderService(new EfOrderRepository(new NorthwindContext()));
//    OrderService  _orderServicedapper = new OrderService(new dapperOrderRepository());
// productService _productServiceEF = new productService(new EfProductRepository(new NorthwindContext()));
// productService _productServicedapper = new productService(new dapperProductRepository());
// orderRequest tmp = new orderRequest (32543,"VINET", 5, DateTime.Now, DateTime.Now, DateTime.Now, 
//     3, 323800);
// orderRequest tmp2 = new orderRequest (10291,"VINET", 5, DateTime.Now, DateTime.Now, DateTime.Now, 
//     3, 323800);
//
//       
//      _orderServicedapper.addOrder(tmp);
//    
//         
//      _orderServiceEF.addOrder(tmp);
//    
//      _orderServicedapper.FindOrder(10291);
//    
//      _orderServiceEF.FindOrder(10291);
//    
//    _orderServicedapper.deleteorder();
//    
//    _orderServiceEF.deleteorder();
// _productServicedapper.joinComplex(1);
// _productServiceEF.joinComplex(1);


// var app = builder.Build();
// app.UseRouting();
//
// app.MapControllers();
// app.Run("http://localhost:5500");
 
using BenchmarkDotNet.Running;
using obada;
using obada.Interface;
using obada.Models;
using obada.Repository;
using obada.Service;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<MvcMovieContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));
builder.Services.AddControllers();
builder.Services.AddDbContext<NorthwindContext>();
builder.Services.AddScoped<IproductRepository, EfProductRepository>();
builder.Services.AddScoped<IprudectService, productService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, dapperOrderRepository>();

BenchmarkRunner.Run<batabaseBenchmarks>();






var app = builder.Build();
app.UseRouting();

app.MapControllers();
app.Run("http://localhost:5500");
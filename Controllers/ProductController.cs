using Microsoft.AspNetCore.Mvc;
using obada.DTO;
using obada.Models;
using obada.Service;

namespace obada.Controllers;

public class ProductController : Controller
{
    private readonly IprudectService _prodectService;
    public ProductController(IprudectService prudectService )
    {
        _prodectService = prudectService;

    }
    
    [HttpGet]
    [Route("/product")]
    public Product GetProduct([FromBody] prudectRequestEnv<productRequest> req)
    {
        return _prodectService.findProduct(req.product);
    }
    
    [HttpGet]
    [Route("/product/{productId}")]
    public Product GetProduct(int productId)
    {
        return _prodectService.findProduct(productId);
    }
    [HttpGet]
    [Route("/productjoin/{productId}")]
    public Product GetProductjoin(int productId)
    {
        return _prodectService.joinComplex(productId);
    }
}
using obada.DTO;
using obada.Interface;
using obada.Models;
namespace obada.Service;

public interface IprudectService
{
    Product addPrudect(productRequest product);
    Product findProduct(productRequest product);
    Product findProduct(int productId);
    bool updateProduct(productRequest product);

}

public class productService :IprudectService
{

    private readonly IproductRepository _productRepository;
    
    public productService(IproductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product addPrudect(productRequest product)
    {
        Product tmpproduct = new Product(product.ProductName,product.SupplierId,product.CategoryId,product.QuantityPerUnit,
        product.UnitPrice,product.UnitsInStock,product.UnitsOnOrder);
        _productRepository.Add(tmpproduct);
        return null;
    }

    public Product findProduct(productRequest product)
    {
        Product tmpproduct = new Product(product.ProductName,product.SupplierId,product.CategoryId,product.QuantityPerUnit,
            product.UnitPrice,product.UnitsInStock,product.UnitsOnOrder);
        return _productRepository.find(tmpproduct);
    }

    public Product findProduct(int productId)
    {
        return _productRepository.find(productId);
    }

    public bool updateProduct(productRequest product)
    {
        throw new NotImplementedException();
    }
}
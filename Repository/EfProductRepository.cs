using obada.Interface;
using obada.Models;

namespace obada.Repository;

public class EfProductRepository:IproductRepository
{
    private readonly NorthwindContext _context;
    public EfProductRepository(NorthwindContext context)
    {
        _context = context;
    }
    public int Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product.ProductId;
    }

    public Product find(int productId)
    {
        return _context.Products.Find(productId);
        
    }

    public Product find(Product product)
    {
      return  _context.Products.FirstOrDefault(x => x.ProductName == product.ProductName);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public dynamic complexJoin(int productId)
    {
        var que  =
        ( from P in _context.Products
            join  S in _context.Suppliers
                on P.SupplierId equals S.SupplierId
                join C in _context.Categories
                on P.CategoryId equals C.CategoryId
            where P.ProductId.Equals(productId)
            select new
            {
                ProductID =P.ProductId,
                ProductName =P.ProductName,
                ProductsSupplierID= P.SupplierId,
                SuppliersSupplierID =S.SupplierId,
                ProductsCategoryID=P.CategoryId
                ,CategoriesCategoryID=C.CategoryId
                ,QuantityPerUnit =P.QuantityPerUnit
                ,UnitPrice =P.UnitPrice,
                UnitsInStock =P.UnitsInStock
                ,SuppliersCompanyName =S.CompanyName,
                SuppliersContactName =S.ContactName,
                SuppliersCountry=S.Country,
                SuppliersPhone = S.Phone,
                CategoriesCategoryName=C.CategoryName,
                CategoriesDescription =C.Description,
            });

        return que.ToList().Last();
        
    }
}
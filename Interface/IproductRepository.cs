using obada.Models;

namespace obada.Interface;

public interface IproductRepository
{
    public int Add(Product product);
    public Product find(int productId);
    public Product find(Product product);
    public void Delete(Product  product);
    public void Update(Product product);
   // public List<UserOld> GetUsersGeneric(Func<UserOld,bool> pred);  
}
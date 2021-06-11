using System.Collections.Generic;
using Entities;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int Id);

        int Add(Product product);

        int Update(Product product);

        int Delete(int Id);
    }
}
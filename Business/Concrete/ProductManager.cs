using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int Id)
        {
            return _productDal.GetById(Id);
        }

        public int Add(Product product)
        {
            return _productDal.Add(product);
        }

        public int Update(Product product)
        {
            return _productDal.Update(product);
        }

        public int Delete(int Id)
        {
            return _productDal.Remove(Id);
        }
    }
}
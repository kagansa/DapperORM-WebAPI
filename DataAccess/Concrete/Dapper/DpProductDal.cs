using Dapper;
using DataAccess.Abstract;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Concrete.Dapper
{
    public class DpProductDal : DapperRepositoryBase, IProductDal
    {
        public DpProductDal(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Product> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>("SELECT * FROM Products").ToList();
        }

        public Product GetById(int productId)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            return connection.QueryFirst<Product>(sql, new { ProductID = productId });
        }

        public int Add(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Products (ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)";

            return connection.Execute(sql, new
            {
                ProductName = product.ProductName,
                SupplierID = product.SupplierId,
                CategoryID = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            });
        }

        public int Remove(int productId)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "DELETE FROM Products WHERE ProductID = @productID;";
            return connection.Execute(sql, new { ProductID = productId });
        }

        public int Update(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE Products SET ProductName=@ProductName,SupplierID=@SupplierID,CategoryID=@CategoryID,QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued WHERE ProductId=@ProductId";

            return connection.Execute(sql, new
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierID = product.SupplierId,
                CategoryID = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            });
        }
    }
}
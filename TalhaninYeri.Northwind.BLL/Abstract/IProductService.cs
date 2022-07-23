using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByFilter(string filter);
        List<Product> GetByCategory(int categoryId);
        List<Product> GetAdvisedProducts();
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetProduct(int productId);
    }
}
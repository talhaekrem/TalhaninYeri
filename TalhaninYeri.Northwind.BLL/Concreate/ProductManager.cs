using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAdvisedProducts()
        {
            return _productDal.GetList(p => p.FirsatUrun == true);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }
        
        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId==0);
        }

        public List<Product> GetByFilter(string filter)
        {
            return _productDal.GetList(p => p.ProductName.Trim().Replace(" ", "").ToLower().Contains(filter.Trim().Replace(" ", "").ToLower()));
        }

        public Product GetProduct(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}

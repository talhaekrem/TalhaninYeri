using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Core.DAL.EntityFramework;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;
using System.Linq;
namespace TalhaninYeri.Northwind.DAL.Concreate.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        NorthwindContext db = new NorthwindContext();

        public void AddSaleCount(int Quantity, int productId)
        {
            var product = db.Products.First(p => p.ProductId == productId);
            product.SaleCount = product.SaleCount + Quantity;
            db.SaveChanges();
        }

        public void ReduceUnitsInStock(int Quantity, int productId)
        {
            var product = db.Products.First(p => p.ProductId == productId);
            product.UnitsInStock = product.UnitsInStock - Quantity;
            db.SaveChanges();
        }

    }
}

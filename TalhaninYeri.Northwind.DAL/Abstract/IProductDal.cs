using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Core.DAL;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.DAL.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        void ReduceUnitsInStock(int Quantity, int productId);

        void AddSaleCount(int Quantity, int productId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TalhaninYeri.Core.DAL.EntityFramework;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.DAL.Concreate.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<Orders, NorthwindContext>, IOrderDetailDal
    {
        NorthwindContext db = new NorthwindContext();
        public void SetDelivered(int orderId)
        {
            var delivered = db.Orders.First(o => o.OrderID == orderId);
            delivered.IsDelivered = true;
            delivered.DeliveredTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}

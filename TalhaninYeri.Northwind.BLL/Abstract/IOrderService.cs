using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface IOrderService
    {
        List<Orders> GetAll();
        List<Orders> GetActiveOrders();
        List<Orders> GetDeliveredOrders();
        Orders GetOrders(int orderId);
        void Add(Orders orderDetail);
        void Delete(int orderId);
    }
}

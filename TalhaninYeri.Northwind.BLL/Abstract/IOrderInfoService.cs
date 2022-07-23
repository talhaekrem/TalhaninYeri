using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface IOrderInfoService
    {
        List<OrderDetails> GetAll();
        List<OrderDetails> GetByOrder(int orderId);
        void Add(OrderDetails orderInfo);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;
using System.Linq;
namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class OrderInfoManager : IOrderInfoService
    {
        private IOrderInfoDal _orderInfoDal;
        public OrderInfoManager(IOrderInfoDal orderInfoDal)
        {
            _orderInfoDal = orderInfoDal;
        }
        public void Add(OrderDetails orderInfo)
        {
            _orderInfoDal.Add(orderInfo);
        }

        public List<OrderDetails> GetAll()
        {
            return _orderInfoDal.GetList();
        }

        public List<OrderDetails> GetByOrder(int orderId)
        {
            return _orderInfoDal.GetList(o => o.OrderID == orderId);
        }
    }
}
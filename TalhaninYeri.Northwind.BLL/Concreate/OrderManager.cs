using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class OrderManager : IOrderService
    {
        private IOrderDetailDal _orderDetailDal;
        public OrderManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public void Add(Orders orderDetail)
        {
            orderDetail.OrderDate = DateTime.Now;
            _orderDetailDal.Add(orderDetail);
        }

        public void Delete(int orderId)
        {
            _orderDetailDal.Delete(new Orders { OrderID = orderId });
        }

        public List<Orders> GetActiveOrders()
        {
            return _orderDetailDal.GetList(o => o.IsDelivered == false);
        }

        public List<Orders> GetAll()
        {
            return _orderDetailDal.GetList();
        }

        public List<Orders> GetDeliveredOrders()
        {
            return _orderDetailDal.GetList(o => o.IsDelivered == true);
        }

        public Orders GetOrders(int orderId)
        {
            return _orderDetailDal.Get(o => o.OrderID == orderId);
        }
    }
}
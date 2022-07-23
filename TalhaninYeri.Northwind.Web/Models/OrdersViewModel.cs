using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class OrdersViewModel
    {
        public List<OrderDetails> OrderDetails { get; set; }

        public List<Orders> Orders { get; set; }

        public Orders orderedProduct { get; set; }

        public List<Product> Products { get; set; }

        public List<Orders> allOrders { get; set; }

        public List<Orders> Delivered { get; set; }
    }
}

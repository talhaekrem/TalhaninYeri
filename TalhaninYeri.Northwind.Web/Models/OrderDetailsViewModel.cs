using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class OrderDetailsViewModel
    {
        public List<OrderDetails> orderInfos { get; set; }

        public Cart Cart { get; set; }

        public Orders OrderDetails { get; set; }
        public int Pcount { get; set; }
    }
}

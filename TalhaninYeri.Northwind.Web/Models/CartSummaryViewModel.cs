using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class CartSummaryViewModel
    {
        public Cart Cart { get; set; }

        public int Pcount { get; set; }
    }
}

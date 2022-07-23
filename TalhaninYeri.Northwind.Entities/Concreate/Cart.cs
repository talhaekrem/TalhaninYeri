using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TalhaninYeri.Northwind.Entities.Concreate
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }

        public decimal SubTotal
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
        public decimal Total
        {
            get 
            { 
                decimal aratoplam = CartLines.Sum(c => c.Product.UnitPrice * c.Quantity);
                aratoplam += Convert.ToDecimal(7);
                return aratoplam;
            }
        }
        public int TotalAmount
        {
            get { return CartLines.Sum(c => c.Quantity); }
        }
    }
}

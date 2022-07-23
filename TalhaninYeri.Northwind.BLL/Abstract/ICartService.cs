using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product, int adet);
        void RemoveFromCart(Cart cart, int productId);
        void ClearCart(Cart cart);
        List<CartLine> List(Cart cart);
    }
}

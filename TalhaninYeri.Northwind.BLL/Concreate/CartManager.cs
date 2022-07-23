using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product, int adet)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if(cartLine != null)
            {
                cartLine.Quantity = cartLine.Quantity + adet;
                return;
            }
            cart.CartLines.Add(new CartLine { Product = product,Quantity = adet });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
        }
        public void ClearCart(Cart cart)
        {
            cart.CartLines.Clear();
        }
    }
}

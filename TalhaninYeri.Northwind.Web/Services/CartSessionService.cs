using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;
using TalhaninYeri.Northwind.Web.ExtensionMethods;

namespace TalhaninYeri.Northwind.Web.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccesor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccesor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                _httpContextAccesor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _httpContextAccesor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccesor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}

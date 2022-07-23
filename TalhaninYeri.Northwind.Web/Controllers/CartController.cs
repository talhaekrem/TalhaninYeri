using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;
using TalhaninYeri.Northwind.Web.Models;
using TalhaninYeri.Northwind.Web.Services;

namespace TalhaninYeri.Northwind.Web.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        private IOrderInfoService _orderInfoService;
        private IOrderService _orderService;
        private IProductDal _productDal;
        public CartController(
            ICartSessionService cartSessionService,
            ICartService cartService,
            IProductService productService,
            IOrderService orderService,
            IOrderInfoService orderInfo,
            IProductDal productDal)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
            _orderInfoService = orderInfo;
            _orderService = orderService;
            _productDal = productDal;
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, string miktar)
        {
            int adet = Convert.ToInt32(miktar);
            string referer = Request.Headers["Referer"].ToString();

            var productToBeAdded = _productService.GetProduct(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded, adet);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("{0} adet {1} ürünü başarıyla eklendi!", adet, productToBeAdded.ProductName));
            return Redirect(referer);
            
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            var model = new CartSummaryViewModel
            {
                Cart = cart,
                Pcount = _productService.GetAll().Count
            };
            ViewBag.productCount = model.Pcount;
            return View(model);
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            if(cart.CartLines.Count != 0)
            {
                TempData.Add("message", String.Format("Ürününüz sepetten başarıyla çıkarıldı!"));
            }
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var cart = _cartSessionService.GetCart();
            var model = new OrderDetailsViewModel
            {
                Cart = cart,
                OrderDetails = new Orders(),
                Pcount = _productService.GetAll().Count
            };
            ViewBag.productCount = model.Pcount;
            return View(model);
        }

        [HttpPost]
        public ActionResult Complete(OrderDetailsViewModel model)
        {
            var cart = _cartSessionService.GetCart();

            if (ModelState.IsValid && cart.CartLines.Count != 0)
            {
                model.OrderDetails.OrderTotal = cart.Total;
                model.OrderDetails.OrderDate = DateTime.Now;
                _orderService.Add(model.OrderDetails);

                for (int i = 0; i < cart.CartLines.Count; i++)
                {
                    OrderDetails details = new OrderDetails();
                    details.OrderID = model.OrderDetails.OrderID;
                    details.ProductID = cart.CartLines[i].Product.ProductId;
                    details.ProductName = cart.CartLines[i].Product.ProductName;
                    details.Quantity = cart.CartLines[i].Quantity;
                    details.UnitPrice = cart.CartLines[i].Product.UnitPrice;
                    _productDal.ReduceUnitsInStock(cart.CartLines[i].Quantity, cart.CartLines[i].Product.ProductId);
                    _productDal.AddSaleCount(cart.CartLines[i].Quantity, cart.CartLines[i].Product.ProductId);
                    _orderInfoService.Add(details);
                }
                TempData.Add("message", String.Format("Teşekkürler {0}. Siparişiniz başarıyla oluşturuldu! Sipariş No: {1}", model.OrderDetails.FirstName, model.OrderDetails.OrderID));
                _cartService.ClearCart(cart);
                _cartSessionService.SetCart(cart);
            }
            return RedirectToAction("Complete");
        }
    }
}
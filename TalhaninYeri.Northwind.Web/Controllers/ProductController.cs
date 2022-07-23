using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.Web.Models;

namespace TalhaninYeri.Northwind.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IImageGalleryService _imageGalleryService;

        public ProductController(
            IProductService productService, 
            ICategoryService categoryService, 
            IImageGalleryService imageGalleryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _imageGalleryService = imageGalleryService;
        }


        public ActionResult Index(int page=1, int category=0)
        {
            int pageSize = 9;

            var products = _productService.GetByCategory(category);
            var categories = _categoryService.GetAll();
            
            ProductModel model = new ProductModel
            {
                Products = products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                Categories = categories,
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"]),
                
                PageCount = (int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize = pageSize,
                CurrentPage = page,
                CurrentCategoryPaging = category,
                Pcount = _productService.GetAll().Count
            };
            ViewBag.productCount = model.Pcount;
            return View(model);
        }

        public ActionResult SearchResult(string filter = "")
        {
            if(filter == null)
            {
                return View();
            }
            else
            {
                var products = _productService.GetByFilter(filter);
                var categories = _categoryService.GetAll();
                ProductModel model = new ProductModel
                {
                    Categories = categories,
                    filter = filter,
                    Products = products,
                    Pcount = _productService.GetAll().Count()
                };
                    ViewBag.Search = filter;
                    ViewBag.Count = model.Products.Count();
                
                ViewBag.productCount = model.Pcount;
                return View(model);
            }

        }

        public ActionResult Detail(int productId)
        {
            var product = _productService.GetProduct(productId);
            var gallery = _imageGalleryService.GetByProduct(productId);
            ProductDetailModel model = new ProductDetailModel
            {
                ProductDetailPage = product,
                imageGallery = gallery,
                Pcount = _productService.GetAll().Count,
                Categories = _categoryService.GetAll()
            };
            ViewBag.productCount = model.Pcount;
            return View(model);
        }
    }
}

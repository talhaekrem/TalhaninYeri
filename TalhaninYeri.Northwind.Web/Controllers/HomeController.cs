using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.Web.Models;

namespace TalhaninYeri.Northwind.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ISliderService _sliderService;
        private ISiteSettingService _siteSettingService;
        private ICategoryService _categoryService;
        private IImageGalleryService _imageGalleryService;
        public HomeController(
            ISliderService sliderService, 
            IProductService productService,
            ISiteSettingService siteSettingService, 
            ICategoryService categoryService,
            IImageGalleryService imageGalleryService)
        {
            _sliderService = sliderService;
            _productService = productService;
            _siteSettingService = siteSettingService;
            _categoryService = categoryService;
            _imageGalleryService = imageGalleryService;
        }
        public ActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel
            {
                Slider = _sliderService.GetByOrder(),
                Product = _productService.GetAdvisedProducts(),
                SiteSetting = _siteSettingService.GetSettings(1),
                Pcount = _productService.GetAll().Count,
                Categories = _categoryService.GetAll(),
                AllProducts = _productService.GetAll(),
                gallery = _imageGalleryService.GetAll()
            };
            ViewBag.productCount = model.Pcount;
            return View(model);
        }

        #region error state
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}

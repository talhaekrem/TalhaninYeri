using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.Web.Models;

namespace TalhaninYeri.Northwind.Web.Controllers
{
    public class ContactController : Controller
    {
        private ISiteSettingService _siteSettingService;
        private IProductService _productService;

        public ContactController(ISiteSettingService siteSettingService, IProductService productService)
        {
            _siteSettingService = siteSettingService;
            _productService = productService;
        }
        public ActionResult Index()
        {
            SiteSettingsModel model = new SiteSettingsModel
            {
                siteSetting = _siteSettingService.GetSettings(1),
                Pcount = _productService.GetAll().Count,

            };
            ViewBag.productCount = model.Pcount;
            return View(model);
        }
    }
}
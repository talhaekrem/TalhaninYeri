using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.Web.Models;

namespace TalhaninYeri.Northwind.Web.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        private ISiteSettingService _siteSettingService;
        public FooterViewComponent(ICategoryService categoryService, ISiteSettingService siteSettingService)
        {
            _categoryService = categoryService;
            _siteSettingService = siteSettingService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new FooterViewModel
            {
                Categories = _categoryService.GetAll(),
                SiteSetting = _siteSettingService.GetSettings(1)
            };

            return View(model);
        }
    }
}

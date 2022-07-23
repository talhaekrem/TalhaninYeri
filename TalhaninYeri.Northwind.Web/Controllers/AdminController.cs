using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;
using TalhaninYeri.Northwind.Web.Models;

namespace TalhaninYeri.Northwind.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IOrderService _orderService;
        private IOrderInfoService _orderInfoService;
        private ISliderService _sliderService;
        private ISiteSettingService _siteSettingService;
        private IOrderDetailDal _orderDetailDal;
        private IImageGalleryService _imageGalleryService;
        private IUserService _userService;

        public AdminController(
            IProductService productService, 
            ICategoryService categoryService, 
            IHostingEnvironment hostingEnvironment,
            IOrderService orderService,
            IOrderInfoService orderInfoService,
            ISliderService sliderService,
            ISiteSettingService siteSettingService,
            IOrderDetailDal orderDetailDal,
            IImageGalleryService imageGalleryService,
            IUserService userService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
            _orderService = orderService;
            _orderInfoService = orderInfoService;
            _sliderService = sliderService;
            _siteSettingService = siteSettingService;
            _orderDetailDal = orderDetailDal;
            _imageGalleryService = imageGalleryService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            var model = new OrdersViewModel
            {
                Orders = _orderService.GetActiveOrders(),
                allOrders = _orderService.GetAll(),
                OrderDetails = _orderInfoService.GetAll(),
                Delivered = _orderService.GetDeliveredOrders()
            };
            return View(model);
        }
        public ActionResult OrderHistory()
        {
            OrderHistoryViewModel model = new OrderHistoryViewModel
            {
                OrderList = _orderService.GetDeliveredOrders()
            };
            return View(model);
        }

        #region sipariş
        public ActionResult OrderDetail(int orderId)
        {
            var model = new OrdersViewModel
            {
                OrderDetails = _orderInfoService.GetByOrder(orderId),
                orderedProduct = _orderService.GetOrders(orderId)
            };
            return View(model);
        }

        public ActionResult OrderDelivered(int orderId)
        {
            _orderDetailDal.SetDelivered(orderId);
            TempData.Add("adminmessage", "Sipariş başarıyla teslim edilmiştir");
            return RedirectToAction("Index");
        }
        #endregion

        #region site ayarları/iletişim güncelle
        public ActionResult SiteSettings()
        {
            var model = new SiteSettingsModel
            {
                siteSetting = _siteSettingService.GetSettings(1)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SiteSettings(SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                _siteSettingService.Update(siteSetting);
                TempData.Add("adminmessage", "Site ayarları başarıyla güncellendi!");
            }

            return RedirectToAction("SiteSettings");
        }
        #endregion

        #region kullanıcılar
        public ActionResult Users()
        {
            var model = new UserViewModel
            {
                User = _userService.GetAll()
            };
            return View(model);
        }
        #endregion

        #region slider
        public ActionResult Slider()
        {
            var model = new SliderModel
            {
                Sliders = _sliderService.GetAll()
            };
            return View(model);
        }
        #endregion

        #region slider ekle
        public ActionResult SliderAdd()
        {
            var model = new SliderAddViewModel
            {
                Slider = new Slider(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SliderAdd(SliderAddViewModel model)
        {
            if (model.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images/sliders");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
                model.Slider.ImagePath = uniqueFileName;
            }

            if (ModelState.IsValid)
            {
                _sliderService.Add(model.Slider);
                TempData.Add("adminmessage", "Slider başarıyla eklendi!");
            }

            return RedirectToAction("SliderAdd");
        }
        #endregion

        #region slider güncelle
        public ActionResult SliderUpdate(int sliderId)
        {
            var model = new SliderAddViewModel
            {
                Slider = _sliderService.GetSlider(sliderId),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SliderUpdate(Slider slider, SliderAddViewModel model)
        {
            if (model.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images/sliders");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
                slider.ImagePath = uniqueFileName;
            }

            _sliderService.Update(slider);
                TempData.Add("adminmessage", "Slider başarıyla güncellendi!");
            

            return RedirectToAction("SliderUpdate");
        }
        #endregion

        #region slider silme
        public ActionResult SliderDelete(int sliderId)
        {
            _sliderService.Delete(sliderId);
            TempData.Add("adminmessage", "Slider başarıyla silindi!");
            return RedirectToAction("Slider");
        }
        #endregion

        #region ürün
        public ActionResult Product()
        {
            var model = new ProductModel
            {
                Products = _productService.GetAll(),
                Categories = _categoryService.GetAll()
                
            };
            return View(model);
        }
        #endregion

        #region ürün ekle
        public ActionResult ProductAdd()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductAdd(ProductAddViewModel model)
        {
            if(model.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img/product-thumb");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
                model.Product.ImagePath = uniqueFileName;
            }
            if (ModelState.IsValid)
            {
                _productService.Add(model.Product);
                if(model.MyImageList != null)
                {
                    for (int i = 0; i < model.MyImageList.Count; i++)
                    {
                        ImageGallery image = new ImageGallery();
                        var uniqueFileName = GetUniqueFileName(model.MyImageList[i].FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img/product-gallery");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        model.MyImageList[i].CopyTo(new FileStream(filePath, FileMode.Create));

                        image.ProductId = model.Product.ProductId;
                        image.Path = uniqueFileName;
                        _imageGalleryService.Add(image);
                    }
                }

            }

                TempData.Add("adminmessage", "Ürün başarıyla eklendi!");
            

            return RedirectToAction("ProductAdd");
        }
        #endregion

        #region ürün güncelle
        public ActionResult ProductUpdate(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetProduct(productId),
                Categories = _categoryService.GetAll(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ProductUpdate(Product product,ProductUpdateViewModel model)
        {
            if (model.ThumbPhotoInput != null)
            {
                var uniqueFileName = GetUniqueFileName(model.ThumbPhotoInput.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img/product-thumb");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.ThumbPhotoInput.CopyTo(new FileStream(filePath, FileMode.Create));
                product.ImagePath = uniqueFileName;
            }
            if(model.GalleryInput != null)
            {
                List<ImageGallery> imagegallery = _imageGalleryService.GetByProduct(product.ProductId);
                if(imagegallery.Count != 0)
                {
                    for (int i = 0; i < model.GalleryInput.Count; i++)
                    {
                        var uniqueFileName = GetUniqueFileName(model.GalleryInput[i].FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img/product-gallery");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        model.GalleryInput[i].CopyTo(new FileStream(filePath, FileMode.Create));

                        imagegallery[i].Path = uniqueFileName;
                        _imageGalleryService.Update(imagegallery[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < model.GalleryInput.Count; i++)
                    {
                        ImageGallery image = new ImageGallery();
                        var uniqueFileName = GetUniqueFileName(model.GalleryInput[i].FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img/product-gallery");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        model.GalleryInput[i].CopyTo(new FileStream(filePath, FileMode.Create));

                        image.ProductId = product.ProductId;
                        image.Path = uniqueFileName;
                        _imageGalleryService.Add(image);
                    }
                }

            }
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("adminmessage", "Ürün başarıyla güncellendi!");
            }

            return RedirectToAction("ProductUpdate");
        }
        #endregion

        #region ürün silme
        public ActionResult ProductDelete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("adminmessage", "Ürün başarıyla silindi!");
            return RedirectToAction("Product");
        }
        #endregion

        #region kategori
        public ActionResult Category()
        {
            var model = new CategoryModel
            {
                Categories = _categoryService.GetAll(),
                Products = _productService.GetAll()
            };
            return View(model);
        }
        #endregion

        #region kategori ekle
        public ActionResult CategoryAdd()
        {
            var model = new CategoryModel
            {
                Category = new Category(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CategoryAdd(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(model.Category);
                TempData.Add("adminmessage", "Kategori başarıyla eklendi!");
            }

            return RedirectToAction("CategoryAdd");
        }
        #endregion

        #region kategori güncelle
        public ActionResult CategoryUpdate(int categoryId)
        {
            var model = new CategoryModel
            {
                Category = _categoryService.GetCategory(categoryId)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                TempData.Add("adminmessage", "Kategori başarıyla güncellendi!");
            }

            return RedirectToAction("CategoryUpdate");
        }
        #endregion

        #region kategori silme
        public ActionResult CategoryDelete(int categoryId)
        {
            int productCount = _productService.GetByCategory(categoryId).Count;
            if(productCount == 0)
            {
                _categoryService.Delete(categoryId);
                TempData.Add("adminmessage", "Kategori başarıyla silindi!");
                return RedirectToAction("Category");
            }
            TempData.Add("CategoryDeleteError", String.Format("{0} kategorisinde {1} tane ürün bulunmaktadır. Ürünler varken kategori silinmez!", _categoryService.GetCategory(categoryId).CategoryName, productCount));
            return RedirectToAction("Category");
        }
        #endregion

        #region benzersiz resim ismi oluşturma
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        #endregion
    }
}

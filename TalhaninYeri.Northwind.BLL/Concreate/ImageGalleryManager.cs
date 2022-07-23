using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class ImageGalleryManager : IImageGalleryService
    {
        private IImageGalleryDal _imageGalleryDal;
        public ImageGalleryManager(IImageGalleryDal imageGalleryDal)
        {
            _imageGalleryDal = imageGalleryDal;
        }
        public void Add(ImageGallery image)
        {
            _imageGalleryDal.Add(image);
        }

        public List<ImageGallery> GetAll()
        {
            return _imageGalleryDal.GetList();
        }

        public List<ImageGallery> GetByProduct(int productId)
        {
            return _imageGalleryDal.GetList(i => i.ProductId == productId);
        }

        public void Update(ImageGallery image)
        {
            _imageGalleryDal.Update(image);
        }
    }
}

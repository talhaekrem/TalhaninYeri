using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface IImageGalleryService
    {
        List<ImageGallery> GetAll();
        List<ImageGallery> GetByProduct(int productId);
        void Add(ImageGallery image);
        void Update(ImageGallery image);
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public ImageGallery ImageGallery { get; set; }
        public List<Category> Categories { get; internal set; }
        public IFormFile MyImage { set; get; }
        public List<IFormFile> MyImageList { get; set; }
    }
}

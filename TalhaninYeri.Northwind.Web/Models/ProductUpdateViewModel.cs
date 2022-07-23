using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; internal set; }
        public List<Category> Categories { get; internal set; }
        public IFormFile ThumbPhotoInput { set; get; }
        public List<IFormFile> GalleryInput { get; set; }
    }
}

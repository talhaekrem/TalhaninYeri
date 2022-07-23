using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class ProductDetailModel
    {
        public Product ProductDetailPage { get; set; }
        public List<ImageGallery> imageGallery { get; set; }
        public List<Category> Categories { get; set; }
        public int Pcount { get; set; }
    }
}

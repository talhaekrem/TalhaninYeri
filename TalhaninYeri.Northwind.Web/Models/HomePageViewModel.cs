using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class HomePageViewModel
    {
        public List<Slider> Slider { get; set;}
        public List<Product> Product { get; set;}
        public SiteSetting SiteSetting {get; set;}
        public List<Category> Categories { get; set; }
        public int Pcount { get; set; }
        public List<Product> AllProducts { get; set; }
        public List<ImageGallery> gallery { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class SliderAddViewModel
    {
        public Slider Slider { get; set; }
        public IFormFile MyImage { set; get; }
    }
}

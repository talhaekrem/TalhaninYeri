using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class FooterViewModel
    {
        public List<Category> Categories { get; internal set; }
        public SiteSetting SiteSetting { get; set; }
    }
}

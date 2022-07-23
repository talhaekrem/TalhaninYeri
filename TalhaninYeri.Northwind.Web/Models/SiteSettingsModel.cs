using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class SiteSettingsModel
    {
        public SiteSetting siteSetting { get; internal set; }
        public int Pcount { get; set; }
    }
}

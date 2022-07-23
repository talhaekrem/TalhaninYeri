using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TalhaninYeri.Core.Entities;

namespace TalhaninYeri.Northwind.Entities.Concreate
{
    public class SiteSetting : IEntity
    {
        [Key]
        public int SiteSettingId { get; set; }

        public string SiteName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string GoogleMap { get; set; }

    }
}

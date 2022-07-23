using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface ISiteSettingService
    {
        SiteSetting GetSettings(int siteSettingId);
        void Add(SiteSetting siteSetting);
        void Update(SiteSetting siteSetting);
        void Delete(int siteSettingId);
    }
}

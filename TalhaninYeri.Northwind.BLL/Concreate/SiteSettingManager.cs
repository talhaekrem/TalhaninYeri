using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class SiteSettingManager : ISiteSettingService
    {
        private ISiteSettingDal _siteSettingDal;
        public SiteSettingManager(ISiteSettingDal siteSettingDal)
        {
            _siteSettingDal = siteSettingDal;
        }

        public void Add(SiteSetting siteSetting)
        {
            _siteSettingDal.Add(siteSetting);
        }

        public void Delete(int siteSettingId)
        {
            _siteSettingDal.Delete(new SiteSetting { SiteSettingId = siteSettingId });
        }

        public SiteSetting GetSettings(int siteSettingId)
        {
            return _siteSettingDal.Get(s => s.SiteSettingId == siteSettingId);
        }

        public void Update(SiteSetting siteSetting)
        {
            _siteSettingDal.Update(siteSetting);
        }
    }
}

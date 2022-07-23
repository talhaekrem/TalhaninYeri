using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface ISliderService
    {
        List<Slider> GetAll();
        List<Slider> GetByOrder();
        Slider GetSlider(int sliderId);
        void Add(Slider slider);
        void Update(Slider slider);
        void Delete(int sliderId);
    }
}

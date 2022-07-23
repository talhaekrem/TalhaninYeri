using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;
using System.Linq;
namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class SliderManager : ISliderService
    {
        private ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }
        public void Add(Slider slider)
        {
            _sliderDal.Add(slider);
        }

        public void Delete(int sliderId)
        {
            _sliderDal.Delete(new Slider { SliderId = sliderId });
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetList();
        }

        public List<Slider> GetByOrder()
        {
            return _sliderDal.GetList().OrderBy(s => s.OrderNumber).ToList();
        }

        public Slider GetSlider(int sliderId)
        {
            return _sliderDal.Get(s => s.SliderId == sliderId);
        }

        public void Update(Slider slider)
        {
            _sliderDal.Update(slider);
        }
    }
}

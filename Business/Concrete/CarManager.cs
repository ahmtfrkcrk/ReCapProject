using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        public CarManager(ICarDal carDal)
        {
            _iCarDal = carDal;
            
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _iCarDal.Add(car);
            }
            else
                throw new DuplicateWaitObjectException("Araç günlük ücreti 0 veya 0 'dan az bir tutar olamaz");
            
        }


        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _iCarDal.GetAll(c => c.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _iCarDal.GetAll(c => c.ColorId == Id);
        }
        
    }
}

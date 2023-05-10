using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public void Delete(Car car)
        {
            _iCarDal.Update(car);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _iCarDal.GetCarDetail();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _iCarDal.GetAll(c => c.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _iCarDal.GetAll(c => c.ColorId == Id);
        }

        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal ,IBrandDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {

                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=1250,Description="Günlük kiralamaya uygun"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=1500,Description="Günlük kiralamaya uygun"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2009,DailyPrice=600,Description="Günlük kiralamaya uygun"},
                new Car{Id=4,BrandId=3,ColorId=3,ModelYear=2022,DailyPrice=3000,Description="Günlük kiralamaya uygun"},
                new Car{Id=5,BrandId=3,ColorId=3,ModelYear=2016,DailyPrice=900,Description="Günlük kiralamaya uygun"}

            };

            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Mercedes Benz"},
                new Brand{BrandId=2,BrandName="Renault Megane"},
                new Brand{BrandId=3,BrandName="Fiat Egea"},
                new Brand{BrandId=4,BrandName="Ford Focus"},
                new Brand{BrandId=5,BrandName="Toyota Corolla"}

            };

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Car car)
        {
            Car deleteToCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteToCar);
        }

        public void Delete(Brand brand)
        {
            Brand deleteToBrand = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(deleteToBrand);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();

        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }

        List<Brand> IBrandDal.GetAll()
        {
            return _brands;
        }

        List<Brand> IBrandDal.GetById(int BrandId)
        {
          return _brands.Where(b => b.BrandId == BrandId).ToList();
           
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {

                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=0,Description="Günlük kiralamaya uygun"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=1500,Description="Günlük kiralamaya uygun"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2009,DailyPrice=600,Description="Günlük kiralamaya uygun"},
                new Car{Id=4,BrandId=3,ColorId=3,ModelYear=2022,DailyPrice=3000,Description="Günlük kiralamaya uygun"},
                new Car{Id=5,BrandId=3,ColorId=3,ModelYear=2016,DailyPrice=900,Description="Günlük kiralamaya uygun"}

            };


        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            Car deleteToCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteToCar);
        }

       

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
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

    }
}

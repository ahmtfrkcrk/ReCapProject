using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car {ColorId=2,DailyPrice=0,ModelYear=2012,Description="Test",BrandId=1});

            foreach (var cM in carManager.GetAll())
            {
                Console.WriteLine(cM.BrandId + " " + cM.ModelYear);
            }




            Console.ReadLine();
        }
    }
    class CarDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}

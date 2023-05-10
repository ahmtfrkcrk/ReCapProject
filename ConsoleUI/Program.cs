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




            // CarDetailTest();
            //CarBrandManagerSelect();

            Console.ReadLine();
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cM in carManager.GetCarDetail())
            {
                Console.WriteLine(cM.CarId + " " + cM.BrandName + " " + cM.ColorName + " " + cM.DailyPrice);
            }
        }

        private static void CarBrandManagerSelect()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { ColorId = 2, DailyPrice = 875, ModelYear = 2012, Description = "Aylık kiralamada %10 daha uygun", BrandId = 4 });
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Dacia" });//Brand Id otomatik artan alan

            foreach (var cM in carManager.GetAll())
            {
                foreach (var bM in brandManager.GetAll())
                {
                    Console.WriteLine(cM.BrandId + " " + bM.BrandName + " " + cM.ModelYear + " " + cM.DailyPrice + " " + cM.Description);
                }

            }
        }
    }
    class CarDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}

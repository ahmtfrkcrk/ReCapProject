using Business.Concrete;
using Business.Constants;
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CariId = 3, CustomerId = 3, RentDate = DateTime.Now, ReturnDate = null });
            

            //CarDetailTest();
            //CarBrandManagerSelect();

            Console.ReadLine();
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetail();

            if (result.Success)
            {
                foreach (var cM in result.Data)
                {
                    Console.WriteLine(cM.CarId + " " + cM.BrandName + " " + cM.ColorName + " " + cM.DailyPrice);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void CarBrandManagerSelect()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { ColorId = 2, DailyPrice = 875, ModelYear = 2012, Description = "Aylık kiralamada %10 daha uygun", BrandId = 4 });
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Ford" });//Brand Id otomatik artan alan

            var result = carManager.GetCarDetail();

            foreach (var cM in result.Data)
            {
                Console.WriteLine(cM.CarId + " " + cM.BrandName + " " + cM.ColorName + " " + cM.DailyPrice);
            }

        }
    }

}

using Business.Concrete;
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

            CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new InMemoryCarDal());

            foreach (var c in carManager.GetAll())
            {
                foreach (var b in brandManager.GetAll())
                {
                    if (c.BrandId==b.BrandId)
                    {
                        Console.WriteLine(c.BrandId+" "+b.BrandName+" "+c.DailyPrice+" "+c.ModelYear);
                    }
                }
            }


            Console.ReadLine();
        }
    }
}

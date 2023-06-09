﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on
                             ca.BrandId equals br.BrandId
                             join co in context.Colors on
                             ca.ColorId equals co.ColorId
                             join mo in context.Models on
                             br.BrandId equals mo.BrandId
                             select new CarDetailDto { 
                                 CarId = ca.Id,
                                 BrandId=ca.BrandId, 
                                 BrandName = br.BrandName,
                                 ModelName=mo.ModelName,
                                 ColorId=ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear=ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description=ca.Description,
                                 ImagePath=(from img in context.CarImages where img.CarId==ca.Id
                                           select img.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrand(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on
                             ca.BrandId equals br.BrandId
                             join co in context.Colors on
                             ca.ColorId equals co.ColorId
                             join mo in context.Models on
                             br.BrandId equals mo.BrandId
                             where ca.BrandId == brandId
                             select new CarDetailDto {
                                 CarId = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ModelName=mo.ModelName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear=ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == ca.Id
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetImageDetailsByCar(int carId)
        {
                using (RentACarContext context = new RentACarContext())
                {
                var result = from ca in context.Cars
                             join br in context.Brands on
                             ca.BrandId equals br.BrandId
                             join co in context.Colors on
                             ca.ColorId equals co.ColorId
                             join mo in context.Models on
                            br.BrandId equals mo.BrandId
                             where ca.Id==carId
                             select new CarDetailDto {
                                 CarId = ca.Id,
                                 BrandName = br.BrandName,
                                 ModelName = mo.ModelName,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear, 
                                 DailyPrice = ca.DailyPrice, 
                                 Description = ca.Description,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == ca.Id
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
            
        }

        public List<CarDetailDto> GetCarDetailsByColor(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on
                             ca.BrandId equals br.BrandId
                             join co in context.Colors on
                             ca.ColorId equals co.ColorId
                             join mo in context.Models on
                             br.BrandId equals mo.BrandId
                             where ca.ColorId==colorId
                             select new CarDetailDto {
                                 CarId = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ModelName = mo.ModelName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear=ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == ca.Id
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

      
    }
}

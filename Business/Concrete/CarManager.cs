using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal )
        {
            _carDal = carDal;
            
        }

        //  [SecuredOperation("Car.Add")] 
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfCarExists(car.BrandId,car.ModelId,car.ModelYear,car.ColorId));
            if (result != null)
            {
                return new ErrorResult(Messages.ThisCarAlreadyExists);
            }
                _carDal.Add(car);
            return new SuccessResult(Messages.Added);
           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        //[SecuredOperation("Car.List")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == Id),Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id),Messages.Listed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        [TransactionScopeAspect]
        public IResult TransactionOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColor(colorId), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrand(brandId), Messages.Listed);
        }
        public IDataResult<List<CarDetailDto>> GetImageDetailsByCar(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetImageDetailsByCar(carId), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
               _carDal.GetCarDetails()
               .Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }
        public IResult CheckIfCarExists(int brandId,int modelId,int modelYear,int colorId)
        {
            //mukerrer kontrol yapıyorum.
            var result = _carDal.GetAll(c => c.BrandId==brandId && c.ModelId==modelId && c.ModelYear==modelYear && c.ColorId==colorId).Any();

            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

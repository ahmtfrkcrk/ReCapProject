using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);


        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetCarRentalDetailsWithCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarRentalDetailsWithCarId(carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.Listed);
        }

        
        public IResult RulesForAdding(Rental rental)
        {
            var result = _rentalDal.Get(r =>
           r.CarId == rental.CarId
           && (r.RentDate == rental.RentDate
           || (r.RentDate < rental.RentDate
           && (r.ReturnDate == null
           || ((DateTime)r.ReturnDate).Date > rental.RentDate))));

            if (result != null)
            {
                return new ErrorResult(Messages.Error);
            }
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == rental.CarId
            && (r.RentDate == rental.RentDate
            || (r.RentDate < rental.RentDate
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > rental.RentDate))));

            if (result != null)
            {
                return new ErrorResult(Messages.Error);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.Error);
                }
            }
            return new SuccessResult();




        }

    }
}

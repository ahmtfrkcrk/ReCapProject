﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult RulesForAdding(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int Id);
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IDataResult<List<RentalDetailDto>> GetCarRentalDetailsWithCarId(int carId);
    }
}

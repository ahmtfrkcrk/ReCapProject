using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from re in context.Rentals
                             join br in context.Brands on
                             re.CarId equals br.BrandId
                             join cu in context.Customers on
                             re.CustomerId equals cu.Id
                             select new RentalDetailDto { Id = re.Id, BrandName = br.BrandName, CustomerName =cu.FirstName + " " + cu.LastName, RentDate = re.RentDate, ReturnDate = re.ReturnDate };
                return result.ToList();
                           

            }
        }
    }
}

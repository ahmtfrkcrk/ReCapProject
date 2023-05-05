using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
            }
            else
                throw new DuplicateWaitObjectException("Araç adı 2 karakterden kısa olamaz.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
    }
}

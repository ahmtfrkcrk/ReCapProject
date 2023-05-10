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
        IBrandDal _iBrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _iBrandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _iBrandDal.Add(brand);
            }
            else
                throw new DuplicateWaitObjectException("Araç adı 2 karakterden kısa olamaz.");
        }

        public void Delete(Brand brand)
        {
            _iBrandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _iBrandDal.Get(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
             _iBrandDal.Update(brand);
        }
    }
}

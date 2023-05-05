using Entities.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        //public decimal DailyPrice
        //{
        //    get { return dailyPrice; }
        //    set {if (value <= 0)
        //            throw new InvalidCastException("Günlük kiralama bedeli 0 veya altında bir bedel olamaz.");
        //        else
        //            dailyPrice = value;
                
        //        ; }
        //}
       
    }
}

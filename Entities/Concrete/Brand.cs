using Entities.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string BrandName;

        private string brandName
        {
            get { return BrandName; }
            set
            {
                if (value.ToString().Length >= 2)
                    BrandName = value;
                else
                    throw new InvalidCastException ("Araba model ismi en az 2 harften oluşmalıdır.");
            }

        }

    }

}

using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.DailyRentalFee);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).Must(BeFirstLetterUppercase).WithMessage("Açıklama kısmı büyük harf ile başlamalıdır.");

        }
        private bool BeFirstLetterUppercase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true; // Boş veya null ise kuralı ihlal etme
            }

            char firstLetter = value.FirstOrDefault();
            return char.IsUpper(firstLetter); // İlk harfin büyük olup olmadığını kontrol et
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Dtos.ProductDtos;
using FluentValidation;

namespace AVB.JwtProje.BusinessLayer.ValidationRules
{

    // dtolar için validationlar
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {

        public ProductAddDtoValidator()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            
            RuleFor(x => x.Name).Length(0, 100).WithMessage("Ad alanı 0-100 karakter arası olmalıdır");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Dtos.ProductDtos;
using FluentValidation;

namespace AVB.JwtProje.BusinessLayer.ValidationRules
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {

        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş geçilemez");
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id pozitif bir sayı olmak zorundadır");


            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");

            RuleFor(x => x.Name).Length(0, 100).WithMessage("Ad alanı 0-100 karakter arası olmalıdır");
        }

    }
}

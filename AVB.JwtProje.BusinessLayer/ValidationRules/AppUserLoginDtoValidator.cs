using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;
using FluentValidation;
using FluentValidation.Validators;

namespace AVB.JwtProje.BusinessLayer.ValidationRules
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
        }
    }
}

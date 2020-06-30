using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;
using FluentValidation;
using FluentValidation.Internal;

namespace AVB.JwtProje.BusinessLayer.ValidationRules
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez");
        }
    }
}

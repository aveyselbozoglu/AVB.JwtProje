using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.BusinessLayer.Concretes;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.BusinessLayer.ValidationRules;
using AVB.JwtProje.DataAccessLayer.Concrete.Repositories;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;
using AVB.JwtProje.Entities.Dtos.ProductDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AVB.JwtProje.BusinessLayer.Containers.MicrosoftIoc
{
    public static class CustomExtension 
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>),typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();


            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IProductService, ProductManager>();


            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();

            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();



            services.AddScoped<IJwtService, JwtManager>();
        }
    }
}

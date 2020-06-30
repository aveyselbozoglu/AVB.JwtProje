using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AVB.JwtProje.Entities.Concrete;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;
using AVB.JwtProje.Entities.Dtos.ProductDtos;

namespace AVB.JwtProje.WebApi.Mapping.AutoMapperProfile
{
     public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>().ReverseMap();

            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<AppUserAddDto, AppUser>().ReverseMap();
        }

    }
}

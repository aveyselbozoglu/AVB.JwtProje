using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.BusinessLayer.StringInfos;
using AVB.JwtProje.Entities.Concrete;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;
using AVB.JwtProje.Entities.Token;
using AVB.JwtProje.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVB.JwtProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _iMapper;

        public AuthController(IJwtService jwtService,IAppUserService appUserService,IMapper iMapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _iMapper = iMapper;
        }


        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
           var appUser= await _appUserService.FindByUserName(appUserLoginDto.UserName);
           if (appUser == null)
               return BadRequest("Kullanıcı adı veya şifre hatalı");


           if (await _appUserService.CheckPassword(appUserLoginDto))
           {
               var roles =await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);

               var token = _jwtService.GenerateJwtToken(appUser, roles);
                JwtAccessToken jwtAccessToken = new JwtAccessToken();
                jwtAccessToken.Token = token;

               
               return Created("", jwtAccessToken);
           }
           return BadRequest("Kullanıcı adı veya şifre hatalı");

        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var checkAppUser =await _appUserService.FindByUserName(appUserAddDto.UserName);

            if (checkAppUser != null)
                return BadRequest($"{checkAppUser.UserName} kullanıcı adı zaten alınmış.");

            var appUser= _iMapper.Map<AppUser>(appUserAddDto);
            await _appUserService.Add(appUser);


            var role =await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.Add(new AppUserRole()
            {
                AppRoleId = role.Id,
                AppUserId = appUser.Id
            });

            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user =await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(User.Identity.Name);

            var appUserDto = new AppUserDto()
            {
                UserName=user.UserName,
                FullName = user.FullName,
                Roles = roles.Select(x=> x.Name).ToList()
            };
            return Ok(appUserDto);
        }
    }
}

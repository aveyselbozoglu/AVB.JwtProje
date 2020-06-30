using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;

namespace AVB.JwtProje.BusinessLayer.Concretes
{
    public class AppUserManager : GenericManager<AppUser> , IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal,IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
        }


        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _appUserDal.GetByFilter(x => x.UserName == userName);
        }

        public async Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserDal.GetByFilter(x => x.Password == appUserLoginDto.Password);

            //await _appUserDal.GetByFilter(x => x.Password == appUserLoginDto.Password);

            //return appUser.Password == appUserLoginDto.Password ? true : false;

            if (appUser != null)
                return true;
            return false;
        }

        public async Task<List<AppRole>> GetRolesByUserName(string username)
        {
            return await _appUserDal.GetRolesByUserName(username);
        }
    }
}

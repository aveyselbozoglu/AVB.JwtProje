using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.Entities.Concrete;
using AVB.JwtProje.Entities.Dtos.AppUserDtos;

namespace AVB.JwtProje.BusinessLayer.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto);

        Task<List<AppRole>> GetRolesByUserName(string username);
    }
}

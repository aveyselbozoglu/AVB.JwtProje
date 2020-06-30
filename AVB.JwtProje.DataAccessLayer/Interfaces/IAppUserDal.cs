using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.DataAccessLayer.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserName(string username);
    }
}

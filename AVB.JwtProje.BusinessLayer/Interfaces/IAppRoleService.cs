using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.BusinessLayer.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> FindByName(string roleName);
    }
}

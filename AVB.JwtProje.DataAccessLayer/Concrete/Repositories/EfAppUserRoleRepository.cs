using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.DataAccessLayer.Concrete.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole>, IAppUserRoleDal
    {
    }
}

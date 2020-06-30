using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.BusinessLayer.Concretes
{
    public class AppUserRoleManager : GenericManager<AppUserRole> , IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {
        }
    }
}

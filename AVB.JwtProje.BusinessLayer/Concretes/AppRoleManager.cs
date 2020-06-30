using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.BusinessLayer.Concretes
{
    public class AppRoleManager : GenericManager<AppRole>,IAppRoleService
    {
        private readonly IGenericDal<AppRole> _genericDal;

        public AppRoleManager(IGenericDal<AppRole> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppRole> FindByName(string roleName)
        {
            return await _genericDal.GetByFilter(x => x.Name == roleName);
        }
    }
}

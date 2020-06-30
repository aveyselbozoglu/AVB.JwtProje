using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.BusinessLayer.StringInfos;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService,
            IAppRoleService appRoleService)
        {

            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);

            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }



            var memberRole = await appRoleService.FindByName(RoleInfo.Member);

            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("veysel");
            if (adminUser == null)
            {
                await appUserService.Add(new AppUser()
                {
                    FullName = "ahmet veysel bozoğlu",
                    Password = "1",
                    UserName = "veysel"
                });


                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("veysel");

                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }

        }
    }
}
